using CAMPUS_NAVIGATION.Classes;
using Google.Api;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CAMPUS_NAVIGATION
{
    public partial class HelpCenter : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private CollectionReference userDataCollection;
        private string originalHelpCenterValue = "";
        public HelpCenter()
        {
            InitializeComponent();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            LoadHelpCenter();
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            userDataCollection = db.Collection("HelpCenter");
        }

        private void HelpCenter_Load(object sender, EventArgs e)
        {
            dataGridView1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            dataGridView1.Width, dataGridView1.Height, 30, 30));

            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnAdd.Width, btnAdd.Height, 30, 30));

            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDelete.Width, btnDelete.Height, 30, 30));

            btnUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnUpdate.Width, btnUpdate.Height, 30, 30));

            txtAnswer.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtAnswer.Width, txtAnswer.Height, 20, 20));

            txtQuestion.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtQuestion.Width, txtQuestion.Height, 20, 20));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            var data = GetWriteData();
            DocumentReference docRef = db.Collection("HelpCenter").Document();

            // Set the data for the document, including the auto-generated ID
            data.ID = docRef.Id; // Assign the auto-generated ID to the 'ID' property

            // Check if the data.Name is not empty or null before creating the DocumentReference
            if (!string.IsNullOrEmpty(data.Question))
            {
                // No need to specify the document name, Firestore will generate one
                docRef.SetAsync(data);
                MessageBox.Show("HelpCenter added successfully.");
                LoadHelpCenter();
            }
            else
            {
                MessageBox.Show("PLEASE FILL UP THE EMPTY BOXES", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Helpcenter GetWriteData()
        {

            string question = txtQuestion.Text.Trim();
            string asnwer = txtAnswer.Text.Trim();


            return new Helpcenter()
            {
                Question = question,
                Answer = asnwer,


            };

        }
        private bool CheckifUserAlreadyExist()
        {
            string question = txtQuestion.Text.Trim();
            string asnwer = txtAnswer.Text.Trim();


            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            DocumentReference docRef = db.Collection("HelpCenter").Document(question);
            Helpcenter data = docRef.GetSnapshotAsync().Result.ConvertTo<Helpcenter>();

            if (data != null)
            {
                MessageBox.Show("User Already Exists");
                return true;
            }

            return false;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Check if there's a selected row
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected user from the selected row
                Helpcenter selectedlostandfound = (Helpcenter)dataGridView1.SelectedRows[0].DataBoundItem;

                // Populate the textboxes with the selected user's data
                txtQuestion.Text = selectedlostandfound.Question;
                txtAnswer.Text = selectedlostandfound.Answer;

            }
            else
            {
                // Clear the textboxes if no row is selected
                txtQuestion.Text = "";
                txtAnswer.Text = "";

            }

        }
        private async void LoadHelpCenter()
        {
            // Initialize Firestore database reference
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Reference to the "HelpCenter" collection
            CollectionReference userDataCollection = db.Collection("HelpCenter");

            // Create a query to retrieve all HelpCenter entries
            QuerySnapshot querySnapshot = await userDataCollection.GetSnapshotAsync();

            // Create a list to store HelpCenter entry data
            List<Helpcenter> helps = new List<Helpcenter>();

            // Loop through the documents and populate the helps list
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                Helpcenter help = documentSnapshot.ConvertTo<Helpcenter>();
                if (help != null)
                {
                    helps.Add(help);
                }
            }

            // Bind the list of HelpCenter entries to the DataGridView
            dataGridView1.DataSource = helps;

            // Remove the "ID" column if it exists
            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Remove("ID");
            }

            // Customize the DataGridView columns to display specific properties
            dataGridView1.AutoResizeColumns();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if there's a value in txtName
            if (string.IsNullOrEmpty(txtQuestion.Text))
            {
                MessageBox.Show("TO DELETE PLEASE ENTER/INPUT FIRST THE QUESTION IN THE TEXTBOX", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Initialize Firestore database reference
            var db = FirestoreHelper.Database;

            // Reference to the "studentorg" collection
            CollectionReference userDataCollection = db.Collection("HelpCenter");

            // Create a query to retrieve the document with the specified value in txtName
            Query query = userDataCollection.WhereEqualTo("Question", txtQuestion.Text);

            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // Check if a document with the specified value exists
            if (querySnapshot.Count > 0)
            {
                // Get the first matching document
                var documentSnapshot = querySnapshot.Documents[0];

                // Delete the document
                await documentSnapshot.Reference.DeleteAsync();

                // Refresh the data in the DataGridView
                LoadHelpCenter();

                MessageBox.Show("Document deleted successfully.");
            }
            else
            {
                MessageBox.Show("HelpCenter not found for deletion.");
            }
        }

        private async Task<bool> UpdateHelpCenter(string currentQuestion, string newQuestion, string newAnswer)
        {
            try
            {
                // Find the document in Firestore based on the current question
                Query query = userDataCollection.WhereEqualTo("Question", currentQuestion);
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

                if (querySnapshot.Count > 0)
                {
                    var documentSnapshot = querySnapshot.Documents[0];
                    var existingHelpCenterData = documentSnapshot.ConvertTo<Helpcenter>();
                    existingHelpCenterData.Question = newQuestion;
                    existingHelpCenterData.Answer = newAnswer;

                    await documentSnapshot.Reference.SetAsync(existingHelpCenterData);

                    return true; // Update successful
                }
                else
                {
                    return false; // Help Center entry not found
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                MessageBox.Show($"Error editing Help Center entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Helpcenter selectedEntry = (Helpcenter)dataGridView1.SelectedRows[0].DataBoundItem;

                string newQuestion = txtQuestion.Text.Trim();
                string newAnswer = txtAnswer.Text.Trim();

                if (!string.IsNullOrEmpty(newQuestion))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to update this Help Center entry?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool updateSuccessful = await UpdateHelpCenter(selectedEntry.Question, newQuestion, newAnswer);

                        if (updateSuccessful)
                        {
                            MessageBox.Show("Help Center entry updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadHelpCenter(); // Refresh the data grid view after updating
                        }
                        else
                        {
                            MessageBox.Show("Help Center entry not found or an error occurred during updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please provide a valid question for the Help Center entry.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("PLEASE SELECT THE ROW IN THE DATA GRID VIEW TO EDIT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
