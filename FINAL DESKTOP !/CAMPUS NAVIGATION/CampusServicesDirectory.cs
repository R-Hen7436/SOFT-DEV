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
    public partial class CampusServicesDirectory : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private string originalServicesValue = "";
        private BindingList<Services> serviceList = new BindingList<Services>();
        public CampusServicesDirectory()
        {
            InitializeComponent();
            dataGridView1.DataSource = serviceList;
        }

        private void CampusServicesDirectory_Load(object sender, EventArgs e)
        {
            txtService.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtService.Width, txtService.Height, 20, 20));

            txtEmail.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtEmail.Width, txtEmail.Height, 20, 20));

            txtContactNum.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtContactNum.Width, txtContactNum.Height, 20, 20));

            dataGridView1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            dataGridView1.Width, dataGridView1.Height, 30, 30));

            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnAdd.Width, btnAdd.Height, 30, 30));

            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDelete.Width, btnDelete.Height, 30, 30));

            btnUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnUpdate.Width, btnUpdate.Height, 30, 30));
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle the CellClick event to populate the textboxes with data from the selected row
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Check if the cell value is not null before accessing it
                txtService.Text = selectedRow.Cells["CampusServices"].Value?.ToString() ?? "";
                txtEmail.Text = selectedRow.Cells["Email"].Value?.ToString() ?? "";
                txtContactNum.Text = selectedRow.Cells["ContactNumber"].Value?.ToString() ?? "";

                // Save the original value for editing
                originalServicesValue = txtService.Text;
            }
        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            var data = GetWriteData();
            DocumentReference docRef = db.Collection("CampusServicesDirectory").Document(data.CampusServices);

            // Set the original value for editing
            originalServicesValue = data.CampusServices;

            // Updated - Save the data without encryption
            Dictionary<string, object> docData = new Dictionary<string, object>
            {
                { "CampusServices", data.CampusServices },
                { "Email", data.Email },
                { "ContactNumber", data.ContactNumber }
            };

            await docRef.SetAsync(docData);

            // Add the data to the BindingList
            serviceList.Add(data);
        }
        private Services GetWriteData()
        {

            string CampusServices = txtService.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string ContactNumber = txtContactNum.Text.Trim(); // Get the Contact Number

            return new Services()
            {
                CampusServices = CampusServices,
                Email = Email,
                ContactNumber = ContactNumber // Set the Contact Number
            };
        }
        private async void LoadServices()
        {
            // Initialize Firestore database reference
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Reference to the "Lostfound" collection
            CollectionReference userDataCollection = db.Collection("CampusServicesDirectory");

            // Create a query to retrieve all users
            QuerySnapshot querySnapshot = await userDataCollection.GetSnapshotAsync();

            // Create a list to store user data
            List<Services> service = new List<Services>();

            // Loop through the documents and populate the losts list
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                Services services = documentSnapshot.ConvertTo<Services>();
                if (services != null)
                {
                    service.Add(services);
                }
            }

            // Bind the list of users to the DataGridView
            dataGridView1.DataSource = service;

            // Customize the DataGridView columns to display specific properties
            dataGridView1.AutoResizeColumns();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if there's a value in textBox1
            if (string.IsNullOrEmpty(txtService.Text))
            {
                MessageBox.Show("Please enter a value in textBox.");
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please enter a value in the Email textbox.");
                return;
            }
            // Initialize Firestore database reference
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Reference to the "Department_Directory" collection
            CollectionReference courseDataCollection = db.Collection("CampusServicesDirectory");

            // Create a query to retrieve the document with the specified value in textBox1
            Query query = courseDataCollection.WhereEqualTo("CampusServices", txtService.Text).WhereEqualTo("Email", txtEmail.Text); ;

            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // Check if a document with the specified value exists
            if (querySnapshot.Count > 0)
            {
                // Get the first matching document
                var documentSnapshot = querySnapshot.Documents[0];

                // Delete the document
                await documentSnapshot.Reference.DeleteAsync();

                // Refresh the data in the DataGridView
                LoadServices();

                MessageBox.Show("Document deleted successfully.");
            }
            else
            {
                MessageBox.Show("Document not found for deletion.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadServices();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            // Check if there's a value in textBox1
            if (string.IsNullOrEmpty(txtService.Text))
            {
                MessageBox.Show("Please enter a value in the Campus Services textbox.");
                return;
            }

            // Initialize Firestore database reference
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Reference to the "CampusServicesDirectory" collection
            CollectionReference courseDataCollection = db.Collection("CampusServicesDirectory");

            // Create a query to retrieve the document with the specified value in textBox1
            Query query = courseDataCollection.WhereEqualTo("CampusServices", originalServicesValue);

            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // Check if a document with the specified value exists
            if (querySnapshot.Count > 0)
            {
                // Get the first matching document
                var documentSnapshot = querySnapshot.Documents[0];

                // Updated - Save the modified data without encryption
                Dictionary<string, object> docData = new Dictionary<string, object>
        {
            { "CampusServices", txtService.Text },
            { "Email", txtEmail.Text },
            { "ContactNumber", txtContactNum.Text }
        };

                await documentSnapshot.Reference.SetAsync(docData);

                // Refresh the data in the DataGridView
                LoadServices();

                MessageBox.Show("Document updated successfully.");
            }
            else
            {
                MessageBox.Show("Document not found for editing.");
            }
        }
    }
}
