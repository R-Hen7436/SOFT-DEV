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
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAMPUS_NAVIGATION.Classes;

namespace CAMPUS_NAVIGATION
{
    public partial class Feedbacks : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);

        public Feedbacks()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void Feedbacks_Load(object sender, EventArgs e)
        {
            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDelete.Width, btnDelete.Height, 30, 30));



            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));

            dataGridView1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            dataGridView1.Width, dataGridView1.Height, 30, 30));

            richTextBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            richTextBox1.Width, richTextBox1.Height, 30, 30));

            textBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBox1.Width, textBox1.Height, 20, 20));
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;

            await LoadUserFeedbackData();
        }

        private async Task LoadUserFeedbackData()
        {
            try
            {
                // Access Firestore using the FirestoreHelper class
                FirestoreHelper.SetEnvironmentVariable();

                // Reference to the Firestore collection
                CollectionReference userFeedbackCollection = FirestoreHelper.Database?.Collection("UserFeedback");

                // Query to fetch data
                QuerySnapshot snapshot = await userFeedbackCollection.GetSnapshotAsync();

                // Clear any existing rows and columns in the dataGridView1
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Add columns to the dataGridView1
                dataGridView1.Columns.Add("CommentColumn", "Comment");
                dataGridView1.Columns.Add("EmailColumn", "Email");
                dataGridView1.Columns.Add("TimestampColumn", "Timestamp");

                // Iterate through each document in the collection
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    // Access specific fields in the document
                    try
                    {
                        string comments = document.GetValue<string>("Comment");
                        string email = document.GetValue<string>("Email");
                        Timestamp timestamp = document.GetValue<Timestamp>("Timestamp");

                        // Convert the Timestamp to a string representation
                        string timestampString = timestamp != null ? timestamp.ToDateTime().ToString() : "";

                        // Add the data to the dataGridView1 as rows
                        dataGridView1.Rows.Add(comments, email, timestampString);
                    }
                    catch (Exception ex)
                    {
                        // Log the exception details to help diagnose the issue
                        Console.WriteLine($"Error processing document: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the comment and email values from the selected row
                string selectedComment = dataGridView1.SelectedRows[0].Cells["CommentColumn"].Value.ToString();
                string selectedEmail = dataGridView1.SelectedRows[0].Cells["EmailColumn"].Value.ToString();

                // Display the comment and email in the RichTextBox and TextBox1
                richTextBox1.Text = selectedComment;
                textBox1.Text = selectedEmail;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    // Get the comment value from the selected row
                    string selectedComment = dataGridView1.SelectedRows[0].Cells["CommentColumn"].Value.ToString();

                    // Access Firestore using the FirestoreHelper class
                    FirestoreHelper.SetEnvironmentVariable();

                    // Reference to the Firestore collection
                    CollectionReference userFeedbackCollection = FirestoreHelper.Database?.Collection("UserFeedback");

                    // Query to find the document with the selected comment
                    QuerySnapshot snapshot = await userFeedbackCollection.WhereEqualTo("Comment", selectedComment).GetSnapshotAsync();

                    // Iterate through the result (there should be only one)
                    foreach (DocumentSnapshot document in snapshot.Documents)
                    {
                        // Delete the document from Firestore
                        await document.Reference.DeleteAsync();
                    }

                    // Refresh the DataGridView
                    await LoadUserFeedbackData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting data: {ex.Message}");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CloseFeedBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}