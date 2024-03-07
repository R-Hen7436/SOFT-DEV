using CAMPUS_NAVIGATION.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAMPUS_NAVIGATION
{
    public partial class EditAccount : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private CollectionReference userDataCollection;
        private List<UserData> originalUsers = new List<UserData>();
        private UserDataService userDataService = new UserDataService();

        public EditAccount()
        {
            InitializeComponent();
            LoadUserData();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void EditAccount_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));

            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel2.Width, panel2.Height, 30, 30));

            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel3.Width, panel3.Height, 30, 30));

            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel4.Width, panel4.Height, 30, 30));

            //textBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            //textBox1.Width, textBox1.Height, 30, 30));

            //textBox2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            //textBox2.Width, textBox2.Height, 30, 30));

            //textBox3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            //textBox3.Width, textBox3.Height, 30, 30));

            //textBox4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            //textBox4.Width, textBox4.Height, 30, 30));

            btnEdit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnEdit.Width, btnEdit.Height, 30, 30));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            // Check if there's a selected row
            if (dataGridView1.SelectedRows.Count > 0)
            {

                // Get the selected user from the selected row
                UserData selectedUser = (UserData)dataGridView1.SelectedRows[0].DataBoundItem;

                // Populate the textboxes with the selected user's data
                textBox1.Text = selectedUser.InstitutionalID;
                textBox2.Text = selectedUser.Name;
                textBox3.Text = selectedUser.Password;
                textBox4.Text = selectedUser.Email;

            }
            else
            {
                // Clear the textboxes if no row is selected
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

            }
        }

        private async void LoadUserData()
        {

            try
            {
                // Use the UserDataService to load user data
                List<UserData> users = await userDataService.LoadUserData();

                // Bind the list of users to the DataGridView
                dataGridView1.DataSource = users;

                // Check if the DataGridView contains the "SecurityID" column
                if (dataGridView1.Columns.Contains("SecurityID"))
                {
                    // Hide the "SecurityID" column
                    dataGridView1.Columns["SecurityID"].Visible = false;
                }

                // Remove the existing "ID" column if it exists
                if (dataGridView1.Columns.Contains("ID"))
                {
                    dataGridView1.Columns.Remove("ID");
                }

                // Customize the DataGridView columns to display specific properties
                dataGridView1.Columns["Email"].DisplayIndex = 2;
                dataGridView1.Columns["InstitutionalID"].DisplayIndex = 0;
                dataGridView1.Columns["Name"].DisplayIndex = 1;
                dataGridView1.Columns["Type"].DisplayIndex = 3;
                dataGridView1.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> EditUser(string currentAccountID, string institutionalId, string newName, string newPassword, string newEmail)
        {
            // Use the UserDataService to edit a user
            var users = await userDataService.LoadUserData();
            var editSuccessful = await userDataService.EditUser(currentAccountID, institutionalId, newName, newPassword, newEmail);

            if (editSuccessful)
            {
                // Find the user with the updated data
                var updatedUser = users.FirstOrDefault(user => user.Name == currentAccountID);

                // Update the SecurityID if the user is found
                if (updatedUser != null)
                {
                    // Update the SecurityID to be the same as the new Password
                    updatedUser.SecurityID = newPassword;

                    // Update the SecurityID in Firebase
                    await userDataService.UpdateSecurityID(updatedUser.ID, updatedUser.SecurityID);
                }

                MessageBox.Show("User edited successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserData(); // Refresh the data grid view after editing
            }
            else
            {
                MessageBox.Show("User not found or an error occurred during editing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return editSuccessful;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            // Check if there's a selected row
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected user from the selected row
                UserData selectedData = (UserData)dataGridView1.SelectedRows[0].DataBoundItem;

                // Get the new user name from the textbox
                string institutionalIdToEdit = textBox1.Text;
                string newName = textBox2.Text;
                string newPassword = textBox3.Text;
                string newEmail = textBox4.Text;


                if (!string.IsNullOrEmpty(institutionalIdToEdit))
                {
                    // Confirm the edit with the user
                    DialogResult result = MessageBox.Show("Are you sure you want to edit this user?", "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Attempt to edit the user
                        bool editSuccessful = await EditUser(selectedData.Name, institutionalIdToEdit, newName, newPassword, newEmail);

                        if (editSuccessful)
                        {
                            MessageBox.Show("user edited successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserData(); // Refresh the data grid view after editing
                        }
                        else
                        {
                            MessageBox.Show("user not found or an error occurred during editing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please provide a valid user name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadUserData();
        }

        private void cbRefresh_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the "cbRefresh" checkbox is checked
            if (cbRefresh.Checked)
            {
                // Refresh the data when the checkbox is checked
                LoadUserData();
            }
        }
    }
}
