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

namespace CAMPUS_NAVIGATION
{
    public partial class DeleteAccount : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private CollectionReference userDataCollection;
        private List<UserData> originalUsers = new List<UserData>();

        public DeleteAccount()
        {
            InitializeComponent();
            LoadUserData();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeleteAccount_Load(object sender, EventArgs e)
        {
            btnDeleteAcc.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDeleteAcc.Width, btnDeleteAcc.Height, 30, 30));

            btnSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnSearch.Width, btnSearch.Height, 30, 30));

            btnRefresh.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnRefresh.Width, btnRefresh.Height, 30, 30));

            //btnUpdateAcc.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            //btnUpdateAcc.Width, btnUpdateAcc.Height, 30, 30));

            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));

            txtSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtSearch.Width, txtSearch.Height, 20, 20));

            //.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            //btnUpdateAcc.Width, btnUpdateAcc.Height, 30, 30));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private List<UserData> FilterUsers(string nameToSearch, string idToSearch)
        {
            // Get the original list of users from the DataGridView's data source
            List<UserData> originalUsers = dataGridView1.DataSource as List<UserData>;

            if (originalUsers == null)
            {
                return new List<UserData>(); // Return an empty list if there's no data source
            }

            // Use LINQ to filter the users based only on the name
            var filteredUsers = originalUsers.Where(user =>
                (string.IsNullOrEmpty(nameToSearch) || user.Name.Contains(nameToSearch, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            return filteredUsers;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string nameToSearch = txtSearch.Text;

            // Filter the user data based on the search criteria (name only)
            List<UserData> filteredUsers = FilterUsers(nameToSearch, string.Empty);

            // Bind the filtered list to the DataGridView
            dataGridView1.DataSource = filteredUsers;
        }

        private async Task<bool> DeleteUser(string institutionalId)
        {
            try
            {
                var userQuery = await userDataCollection.WhereEqualTo("InstitutionalID", institutionalId).GetSnapshotAsync();

                foreach (var document in userQuery.Documents)
                {
                    await document.Reference.DeleteAsync();
                }

                return true; // Deletion successful
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void LoadUserData()
        {
            try
            {
                FirestoreHelper.SetEnvironmentVariable();
                FirestoreDb database = FirestoreHelper.Database;

                // Assign the value to the class-level userDataCollection field
                userDataCollection = database.Collection("UserData");
                // Create a query to retrieve all users
                QuerySnapshot querySnapshot = await userDataCollection.GetSnapshotAsync();

                // Create a list to store user data
                List<UserData> users = new List<UserData>();

                // Loop through the documents and populate the users list
                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    // Convert the document to UserData
                    UserData user = documentSnapshot.ConvertTo<UserData>();

                    if (user != null)
                    {
                        // Decrypt the password before adding it to the list
                        user.Password = Security.Decrypt(user.Password);
                        users.Add(user);
                    }
                }

                // Clear the existing data source before setting the new one
                dataGridView1.DataSource = null;

                // Store the original unfiltered user data
                originalUsers = users;

                // Bind the list of users to the DataGridView
                dataGridView1.DataSource = users;

                // Check if the DataGridView contains the "SecurityID" column
                if (dataGridView1.Columns.Contains("SecurityID"))
                {
                    // Hide the "SecurityID" column
                    dataGridView1.Columns["SecurityID"].Visible = false;
                }

                if (dataGridView1.Columns.Contains("InstitutionalID"))
                {
                    dataGridView1.Columns["InstitutionalID"].Visible = false;
                }
                else
                {
                    // Handle the case where the "InstitutionalID" column is not found, e.g., display a message or log an error.
                    MessageBox.Show("The 'InstitutionalID' column was not found in the DataGridView.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Customize the DataGridView columns to display specific properties
                dataGridView1.Columns["Password"].Visible = true; // Make the Password column visible
                dataGridView1.Columns["Email"].DisplayIndex = 2;
                dataGridView1.Columns["InstitutionalID"].DisplayIndex = 0;
                dataGridView1.Columns["InstitutionalID"].Visible = false; // Hide the column with random letters/numbers
                dataGridView1.Columns["Name"].DisplayIndex = 1;
                dataGridView1.Columns["Type"].DisplayIndex = 3;

                dataGridView1.AutoResizeColumns();

                // Remove the column named "ID" if it's found in the DataGridView
                if (dataGridView1.Columns.Contains("ID"))
                {
                    // Remove the existing "ID" column to avoid duplication
                    dataGridView1.Columns.Remove("ID");
                }

                // Add the "ID" column only if it's not found in the DataGridView
                if (!dataGridView1.Columns.Contains("ID"))
                {
                    var idColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "ID",
                        DataPropertyName = "InstitutionalID",
                        Visible = true,
                        DisplayIndex = 0
                    };
                    dataGridView1.Columns.Insert(0, idColumn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            // Check if there's a selected row
            if (dataGridView1.SelectedRows.Count > 0)
            {

                // Get the selected user from the selected row
                UserData selectedUser = (UserData)dataGridView1.SelectedRows[0].DataBoundItem;

                // Populate the textboxes with the selected user's data
                txtSearch.Text = selectedUser.Name;

            }
            else
            {
                // Clear the textboxes if no row is selected
                txtSearch.Text = "";

            }
        }

        private async void btnDeleteAcc_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Please enter the name in the textbox to delete the account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userDataCollection == null)
            {
                MessageBox.Show("User data collection is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string nameToSearch = txtSearch.Text;

                var userToDelete = originalUsers.FirstOrDefault(u => u.Name.Equals(nameToSearch, StringComparison.OrdinalIgnoreCase));

                if (userToDelete != null)
                {
                    bool deletionResult = await DeleteUser(userToDelete.InstitutionalID);

                    if (deletionResult)
                    {
                        LoadUserData(); // Refresh the data after deletion
                        MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete the account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("User not found for deletion.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
