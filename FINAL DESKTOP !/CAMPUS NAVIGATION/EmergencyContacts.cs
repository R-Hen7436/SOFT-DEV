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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CAMPUS_NAVIGATION
{
    public partial class EmergencyContacts : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private CollectionReference userDataCollection;
        private string originalCoursesValue = "";
        public EmergencyContacts()
        {
            InitializeComponent();
            LoadEmergencyContacts();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            userDataCollection = db.Collection("EmergencyContacts");
        }

        private void EmergencyContacts_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));

            txtName.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtName.Width, txtName.Height, 20, 20));

            txtNumber.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtNumber.Width, txtNumber.Height, 20, 20));

            txtLocation.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtLocation.Width, txtLocation.Height, 20, 20));

            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnAdd.Width, btnAdd.Height, 30, 30));

            btnSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnSearch.Width, btnSearch.Height, 30, 30));

            btnEdit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnEdit.Width, btnEdit.Height, 30, 30));

            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDelete.Width, btnDelete.Height, 30, 30));

            dataGridView1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            dataGridView1.Width, dataGridView1.Height, 30, 30));

            textBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBox1.Width, textBox1.Height, 20, 20));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private List<Emergency_Contacts> FilterUsers(string nameToSearch, string idToSearch)
        {
            // Get the original list of users from the DataGridView's data source
            List<Emergency_Contacts> originalUsers = dataGridView1.DataSource as List<Emergency_Contacts>;

            if (originalUsers == null)
            {
                return new List<Emergency_Contacts>(); // Return an empty list if there's no data source
            }

            // Use LINQ to filter the users based on the search criteria
            var filteredUsers = originalUsers.Where(user =>
                (string.IsNullOrEmpty(nameToSearch) || user.Name.Contains(nameToSearch, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(idToSearch) || user.Number.Contains(idToSearch, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            return filteredUsers;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search criteria from the textbox
            string nameToSearch = textBox1.Text;

            // Check if the search criteria is empty
            if (string.IsNullOrEmpty(nameToSearch))
            {
                MessageBox.Show("PLEASE ENTER A VALUE IN THE TEXTBOX TO SEARCH.", "Empty Search Criteria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idToSearch = ""; // You can add the logic for this as needed

            // Filter the user data based on the search criteria
            List<Emergency_Contacts> filteredUsers = FilterUsers(nameToSearch, idToSearch);

            // Bind the filtered list to the DataGridView
            dataGridView1.DataSource = filteredUsers;

            // Remove the "ID" column if it exists in the DataGridView
            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Remove("ID");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            var data = GetWriteData();

            if (!string.IsNullOrEmpty(data.Name))
            {
                await userDataCollection.AddAsync(data);
                MessageBox.Show("Emergency Contacts added successfully.");
                LoadEmergencyContacts();
            }
            else
            {
                MessageBox.Show("PLEASE FILL UP THE EMPTY BOXES", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private Emergency_Contacts GetWriteData()
        {

            string name = txtName.Text.Trim();
            string mobile = txtNumber.Text.Trim();
            string location = txtLocation.Text.Trim();


            return new Emergency_Contacts()
            {
                Name = name,
                Number = mobile,
                Location = location,

            };

        }
        private bool CheckifUserAlreadyExist()
        {
            string name = txtName.Text.Trim();
            string mobile = txtNumber.Text.Trim();
            string telephone = txtLocation.Text.Trim();

            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            DocumentReference docRef = db.Collection("EmergencyContacts").Document(name);
            Emergency_Contacts data = docRef.GetSnapshotAsync().Result.ConvertTo<Emergency_Contacts>();

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
                Emergency_Contacts selectedlostandfound = (Emergency_Contacts)dataGridView1.SelectedRows[0].DataBoundItem;

                // Populate the textboxes with the selected user's data
                txtName.Text = selectedlostandfound.Name;
                txtNumber.Text = selectedlostandfound.Number;
                txtLocation.Text = selectedlostandfound.Location;

            }
            else
            {
                // Clear the textboxes if no row is selected
                txtName.Text = "";
                txtNumber.Text = "";
                txtLocation.Text = "";

            }

        }
        private async void LoadEmergencyContacts()
        {
            // Initialize Firestore database reference
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Reference to the "Lostfound" collection
            CollectionReference userDataCollection = db.Collection("EmergencyContacts");

            // Create a query to retrieve all users
            QuerySnapshot querySnapshot = await userDataCollection.GetSnapshotAsync();

            // Create a list to store user data
            List<Emergency_Contacts> contacts = new List<Emergency_Contacts>();

            // Loop through the documents and populate the losts list
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                Emergency_Contacts contact = documentSnapshot.ConvertTo<Emergency_Contacts>();

                if (contact != null)
                {
                    // Set the ID property with the document ID
                    contact.ID = documentSnapshot.Id;
                    contacts.Add(contact);
                }
            }

            // Bind the list of users to the DataGridView
            dataGridView1.DataSource = contacts;

            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Remove("ID");
            }
            // Customize the DataGridView columns to display specific properties
            dataGridView1.AutoResizeColumns();
        }


        private async void btnDelete_Click(object sender, EventArgs e)

        { // Check if there's a value in txtName
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("TO DELETE PLEASE ENTER FIRST THE NAME IN THE TEXTBOX", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Initialize Firestore database reference
            var db = FirestoreHelper.Database;

            // Reference to the "EmergencyContacts" collection
            CollectionReference userDataCollection = db.Collection("EmergencyContacts");

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
                LoadEmergencyContacts();

                MessageBox.Show("Document deleted successfully.");
            }
            else
            {
                MessageBox.Show("Organization not found for deletion.");
            }
        }
        private async Task<string> GetDocumentId(string contactName)
        {
            try
            {
                var snapshot = await userDataCollection.WhereEqualTo("Name", contactName).Limit(1).GetSnapshotAsync();

                if (snapshot.Count > 0)
                {
                    var document = snapshot.Documents.First();
                    return document.Id;
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting document ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private async Task<bool> UpdateEmergencyContact(string currentContactId, string newName, string newNumber, string newLocation)
        {
            try
            {
                // Get the existing contact data
                var existingContactData = await userDataCollection.Document(currentContactId).GetSnapshotAsync();
                var existingContact = existingContactData.ConvertTo<Emergency_Contacts>();

                if (existingContact != null)
                {
                    // Update the contact data
                    existingContact.Name = newName;
                    existingContact.Number = newNumber;
                    existingContact.Location = newLocation;

                    // Set the updated data back to Firestore
                    await userDataCollection.Document(currentContactId).SetAsync(existingContact);

                    return true; // Update successful
                }
                else
                {
                    MessageBox.Show("Contact not found for updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; // Contact not found
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing contact: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Emergency_Contacts selectedContact = (Emergency_Contacts)dataGridView1.SelectedRows[0].DataBoundItem;

                string newName = txtName.Text.Trim();
                string newNumber = txtNumber.Text.Trim();
                string newLocation = txtLocation.Text.Trim();

                if (!string.IsNullOrEmpty(newName))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to update this contact?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Use the ID of the selected contact to update it
                        string currentContactID = selectedContact.ID;

                        if (currentContactID != null)
                        {
                            bool updateSuccessful = await UpdateEmergencyContact(currentContactID, newName, newNumber, newLocation);

                            if (updateSuccessful)
                            {
                                MessageBox.Show("Contact updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadEmergencyContacts(); // Refresh the data grid view after updating
                            }
                            else
                            {
                                MessageBox.Show("An error occurred during updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Contact ID is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please provide a valid contact name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a contact row to Edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}


