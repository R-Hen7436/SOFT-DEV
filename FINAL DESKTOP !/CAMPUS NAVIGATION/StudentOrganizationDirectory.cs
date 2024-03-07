using CAMPUS_NAVIGATION.Classes;
using Google.Cloud.Firestore;
using Microsoft.VisualBasic.Devices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CAMPUS_NAVIGATION
{
    public partial class StudentOrganizationDirectory : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private CollectionReference userDataCollection;
        private string originalOrganizationValue = "";
        public StudentOrganizationDirectory()
        {
            InitializeComponent();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            userDataCollection = db.Collection("studentorg");
            LoadOrganizationData();
        }

        private void StudentOrganizationDirectory_Load(object sender, EventArgs e)
        {
            txtDescripton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtDescripton.Width, txtDescripton.Height, 20, 20));

            txtName.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtName.Width, txtName.Height, 20, 20));

            txtOrg.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtOrg.Width, txtOrg.Height, 20, 20));

            dataGridView1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            dataGridView1.Width, dataGridView1.Height, 30, 30));

            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnAdd.Width, btnAdd.Height, 30, 30));

            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDelete.Width, btnDelete.Height, 30, 30));

            btnUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnUpdate.Width, btnUpdate.Height, 30, 30));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            var data = GetWriteData();

            DocumentReference docRef = db.Collection("studentorg").Document();

            // Set the data for the document, including the auto-generated ID
            data.ID = docRef.Id; // Assign the auto-generated ID to the 'ID' property

            originalOrganizationValue = data.Name; // Store the original value

            if (!string.IsNullOrEmpty(data.Name))
            {
                // No need to specify the document name, Firestore will generate one
                docRef.SetAsync(data);
                MessageBox.Show("Organization added successfully.");
                LoadOrganizationData();
            }
            else
            {
                MessageBox.Show("PLEASE FILL UP THE EMPTY BOXES", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private StudentOrg GetWriteData()
        {

            string name = txtName.Text.Trim();
            string department = txtOrg.Text.Trim();
            string description = txtDescripton.Text.Trim();


            return new StudentOrg()
            {
                Name = name,
                Department = department,
                Description = description,


            };

        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Check if there's a selected row
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected user from the selected row
                StudentOrg selectedOrganization = (StudentOrg)dataGridView1.SelectedRows[0].DataBoundItem;

                // Populate the textboxes with the selected user's data
                txtName.Text = selectedOrganization.Name;
                txtOrg.Text = selectedOrganization.Department;
                txtDescripton.Text = selectedOrganization.Description;

            }
            else
            {
                // Clear the textboxes if no row is selected
                txtName.Text = "";
                txtDescripton.Text = "";
                txtOrg.Text = "";

            }
        }

        private async void LoadOrganizationData()
        {
            // Initialize Firestore database reference
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Reference to the "Lostfound" collection
            CollectionReference userDataCollection = db.Collection("studentorg");

            // Create a query to retrieve all users
            QuerySnapshot querySnapshot = await userDataCollection.GetSnapshotAsync();

            // Create a list to store user data
            List<StudentOrg> org = new List<StudentOrg>();

            // Loop through the documents and populate the losts list
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                StudentOrg orgs = documentSnapshot.ConvertTo<StudentOrg>();
                if (orgs != null)
                {
                    org.Add(orgs);
                }
            }

            // Bind the list of users to the DataGridView
            dataGridView1.DataSource = org;

            


            // Set column widths for specific columns
            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns["ID"].Visible = false;
            }
            dataGridView1.Columns["Name"].Width = 150; // Set the width for the 'Name' column
            dataGridView1.Columns["Department"].Width = 150; // Set the width for the 'Department' column
            // Customize the DataGridView columns to display specific properties
         
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if there's a value in txtName
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("TO DELETE PLEASE ENTER/SELECT THE ORGANIZATION NAME IN THE TEXTBOX", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Initialize Firestore database reference
            var db = FirestoreHelper.Database;

            // Reference to the "studentorg" collection
            CollectionReference userDataCollection = db.Collection("studentorg");

            // Create a query to retrieve the document with the specified value in txtName
            Query query = userDataCollection.WhereEqualTo("Name", txtName.Text);

            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // Check if a document with the specified value exists
            if (querySnapshot.Count > 0)
            {
                // Get the first matching document
                var documentSnapshot = querySnapshot.Documents[0];

                // Delete the document
                await documentSnapshot.Reference.DeleteAsync();

                // Refresh the data in the DataGridView
                LoadOrganizationData();

                MessageBox.Show("Document deleted successfully.");
            }
            else
            {
                MessageBox.Show("Organization not found for deletion.");
            }
        }

        private async Task<bool> EditOrganization(string currentOrganizationName, string newName, string newDepartment, string newDescription)
        {
            try
            {
                // Find the document in Firestore based on the current organization name
                Query query = userDataCollection.WhereEqualTo("Name", currentOrganizationName);
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

                if (querySnapshot.Count > 0)
                {
                    var documentSnapshot = querySnapshot.Documents[0];
                    var existingOrgData = documentSnapshot.ConvertTo<StudentOrg>();

                    existingOrgData.Name = newName;
                    existingOrgData.Department = newDepartment;
                    existingOrgData.Description = newDescription;

                    await documentSnapshot.Reference.SetAsync(existingOrgData);

                    return true; // Update successful
                }
                else
                {
                    return false; // Organization not found
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                MessageBox.Show($"Error editing organization: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                StudentOrg selectedOrg = (StudentOrg)dataGridView1.SelectedRows[0].DataBoundItem;

                string newName = txtName.Text.Trim();
                string newDepartment = txtOrg.Text.Trim();
                string newDescription = txtDescripton.Text.Trim();

                if (!string.IsNullOrEmpty(newName))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to update this organization?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool updateSuccessful = await EditOrganization(selectedOrg.Name, newName, newDepartment, newDescription);

                        if (updateSuccessful)
                        {
                            MessageBox.Show("Organization updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOrganizationData();
                        }
                        else
                        {
                            MessageBox.Show("Organization not found or an error occurred during updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please provide a valid organization name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
