using CAMPUS_NAVIGATION.Classes;
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

namespace CAMPUS_NAVIGATION
{
    public partial class LostandFound : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);

        private CollectionReference userDataCollection;
        private string originalLostFoundValue = "";
        public LostandFound()
        {
            InitializeComponent();
            LoadLostAndFound();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            userDataCollection = db.Collection("Lostfound");
        }

        private void LostandFound_Load(object sender, EventArgs e)
        {
            dataGridView1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            dataGridView1.Width, dataGridView1.Height, 30, 30));

            textBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBox1.Width, textBox1.Height, 20, 20));

            textBox2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBox2.Width, textBox2.Height, 20, 20));

            textBox3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBox3.Width, textBox3.Height, 20, 20));

            textBox4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBox4.Width, textBox4.Height, 20, 20));

            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));

            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel2.Width, panel2.Height, 30, 30));

            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDelete.Width, btnDelete.Height, 30, 30));

            btnEdit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnEdit.Width, btnEdit.Height, 30, 30));

            btnUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnUpdate.Width, btnUpdate.Height, 30, 30));

            textBox5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBox5.Width, textBox5.Height, 30, 30));
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // Check if there's a value in txtName
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("TO DELETE PLEASE ENTER FIRST THE NAME IN THE TEXTBOX", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Initialize Firestore database reference
            var db = FirestoreHelper.Database;

            // Reference to the "Lostfound" collection
            CollectionReference userDataCollection = db.Collection("Lostfound");

            // Create a query to retrieve the document with the specified value in txtName
            Query query = userDataCollection.WhereEqualTo("Name", textBox1.Text);

            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // Check if a document with the specified value exists
            if (querySnapshot.Count > 0)
            {
                // Get the first matching document
                var documentSnapshot = querySnapshot.Documents[0];

                // Delete the document
                await documentSnapshot.Reference.DeleteAsync();

                // Refresh the data in the DataGridView
                LoadLostAndFound();

                MessageBox.Show("DOCUMENT DELETED SUCCESSFULLY.");
            }
            else
            {
                MessageBox.Show("ITEM NOT FOUND FOR DELETION");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            var data = GetWriteData();

            DocumentReference docRef = db.Collection("Lostfound").Document();

            // Set the data for the document, including the auto-generated ID
            data.ID = docRef.Id; // Assign the auto-generated ID to the 'ID' property

            // Check if the data.Name is not empty or null before creating the DocumentReference
            if (!string.IsNullOrEmpty(data.Name))
            {
                // No need to specify the document name, Firestore will generate one
                docRef.SetAsync(data);
                MessageBox.Show("ITEMS ADDED SUCCESSFULLY.");
                LoadLostAndFound();
            }
            else
            {
                MessageBox.Show("PLEASE FILL UP THE EMPTY BOX.");
            }
        }

        private LostFound GetWriteData()
        {

            string name = textBox1.Text.Trim();
            string place = textBox3.Text.Trim();
            string item = textBox2.Text.Trim();
            string others = textBox4.Text.Trim();
            string claimhere = textBox5.Text.Trim();

            return new LostFound()
            {
                Name = name,
                Place = place,
                Items = item,
                Others = others,

            };

        }

        private bool CheckifUserAlreadyExist()
        {

            string name = textBox1.Text.Trim();
            string place = textBox2.Text.Trim();
            string item = textBox3.Text.Trim();
            string others = textBox3.Text.Trim();
            string claimhere = textBox5.Text.Trim();
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            DocumentReference docRef = db.Collection("Lostfound").Document(name);
            LostFound data = docRef.GetSnapshotAsync().Result.ConvertTo<LostFound>();

            if (data != null)
            {
                MessageBox.Show("User Already Exists");
                return true;
            }

            return false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadLostAndFound();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Check if there's a selected row
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected user from the selected row
                LostFound selectedlostandfound = (LostFound)dataGridView1.SelectedRows[0].DataBoundItem;

                // Populate the textboxes with the selected user's data
                textBox1.Text = selectedlostandfound.Name;
                textBox2.Text = selectedlostandfound.Items;
                textBox3.Text = selectedlostandfound.Place;
                textBox4.Text = selectedlostandfound.Others;

                // Display the ClaimHere data in textBox5
                textBox5.Text = selectedlostandfound.ClaimHere;
            }
            else
            {
                // Clear the textboxes if no row is selected
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = ""; // Clear textBox5 when no row is selected
            }
        }

        private async void LoadLostAndFound()
        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Reference to the "Lostfound" collection
            CollectionReference userDataCollection = db.Collection("Lostfound");

            // Create a query to retrieve all users
            QuerySnapshot querySnapshot = await userDataCollection.GetSnapshotAsync();

            // Create a list to store user data
            List<LostFound> losts = new List<LostFound>();

            // Loop through the documents and populate the losts list
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                LostFound lost = documentSnapshot.ConvertTo<LostFound>();
                if (lost != null)
                {
                    losts.Add(lost);
                }
            }

            // Bind the list of users to the DataGridView
            dataGridView1.DataSource = losts;

            // Remove the "ID" column if it exists
            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Remove("ID");
            }

            // Add or update the columns based on the LostFound class properties
            UpdateDataGridViewColumns(dataGridView1, typeof(LostFound));

            // Customize the DataGridView columns to display specific properties
            dataGridView1.AutoResizeColumns();
        }

        private void UpdateDataGridViewColumns(DataGridView dataGridView, Type dataType)
        {
            // Clear existing columns
            dataGridView.Columns.Clear();

            // Add columns based on the properties of the data type
            foreach (var property in dataType.GetProperties())
            {
                // Exclude the "ID" property
                if (property.Name != "ID")
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.DataPropertyName = property.Name;
                    column.HeaderText = property.Name;
                    dataGridView.Columns.Add(column);
                }
            }
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async Task<bool> UpdateLostAndFound(string currentName, string newName, string newPlace, string newItems, string newOthers)
        {
            try
            {
                // Find the document in Firestore based on the current name
                Query query = userDataCollection.WhereEqualTo("Name", currentName);
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

                if (querySnapshot.Count > 0)
                {
                    var documentSnapshot = querySnapshot.Documents[0];
                    var existingLostAndFoundData = documentSnapshot.ConvertTo<LostFound>();
                    existingLostAndFoundData.Name = newName;
                    existingLostAndFoundData.Place = newPlace;
                    existingLostAndFoundData.Items = newItems;
                    existingLostAndFoundData.Others = newOthers;

                    existingLostAndFoundData.ClaimHere = textBox5.Text.Trim();
                    await documentSnapshot.Reference.SetAsync(existingLostAndFoundData);

                    return true; // Update successful
                }
                else
                {
                    return false; // Lost and Found entry not found
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                MessageBox.Show($"Error editing Lost and Found entry: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                LostFound selectedEntry = (LostFound)dataGridView1.SelectedRows[0].DataBoundItem;

                string newName = textBox1.Text.Trim();
                string newPlace = textBox3.Text.Trim();
                string newItems = textBox2.Text.Trim();
                string newOthers = textBox4.Text.Trim();

                if (!string.IsNullOrEmpty(newName))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to update this Lost and Found entry?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool updateSuccessful = await UpdateLostAndFound(selectedEntry.Name, newName, newPlace, newItems, newOthers);

                        if (updateSuccessful)
                        {
                            MessageBox.Show("Lost and Found entry updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadLostAndFound(); // Refresh the data grid view after updating
                        }
                        else
                        {
                            MessageBox.Show("Lost and Found entry not found or an error occurred during updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please provide a valid name for the Lost and Found entry.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a Lost and Found entry to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}

