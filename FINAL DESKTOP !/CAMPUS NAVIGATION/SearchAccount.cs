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
    public partial class SearchAccount : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private CollectionReference userDataCollection;

        public SearchAccount()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void SearchAccount_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));

            txtSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtSearch.Width, txtSearch.Height, 20, 20));

            btnUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnUpdate.Width, btnUpdate.Height, 30, 30));

            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            button1.Width, button1.Height, 30, 30));

            dataGridView1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            dataGridView1.Width, dataGridView1.Height, 30, 30));
        }

        private async void LoadUserData()
        {
            try
            {

                FirestoreHelper.SetEnvironmentVariable();
                FirestoreDb database = FirestoreHelper.Database;
                // Initialize Firestore database reference


                // Reference to the "UserData" collection
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

                // Store the original unfiltered user data


                // Bind the list of users to the DataGridView
                dataGridView1.DataSource = users;

                if (dataGridView1.Columns.Contains("ID"))
                {
                    // Remove the existing "ID" column to avoid duplication
                    dataGridView1.Columns.Remove("ID");
                }

                // Check if the DataGridView contains the "SecurityID" column
                if (dataGridView1.Columns.Contains("SecurityID"))
                {
                    // Hide the "SecurityID" column
                    dataGridView1.Columns["SecurityID"].Visible = false;
                }



                // Customize the DataGridView columns to display specific properties
                //dataGridView1.Columns["Password"].Visible = true; // Make the Password column visible
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

        private List<UserData> FilterUsers(string nameToSearch, string idToSearch)
        {
            // Get the original list of users from the DataGridView's data source
            List<UserData> originalUsers = dataGridView1.DataSource as List<UserData>;

            if (originalUsers == null)
            {
                return new List<UserData>(); // Return an empty list if there's no data source
            }

            // Use LINQ to filter the users based on the search criteria
            var filteredUsers = originalUsers.Where(user =>
                (string.IsNullOrEmpty(nameToSearch) || user.Name.Contains(nameToSearch, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(idToSearch) || user.InstitutionalID.Contains(idToSearch, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            return filteredUsers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Get the search criteria from the textboxes
            string nameToSearch = txtSearch.Text;
            string idToSearch = "";

            // Filter the user data based on the search criteria
            List<UserData> filteredUsers = FilterUsers(nameToSearch, idToSearch);

           
            // Bind the filtered list to the DataGridView
            dataGridView1.DataSource = filteredUsers;
            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Remove("ID");
            }
        }
    }
}
