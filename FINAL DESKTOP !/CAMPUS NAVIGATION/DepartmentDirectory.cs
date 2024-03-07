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
    public partial class DepartmentDirectory : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private CollectionReference courseDataCollection;
        private string originalCoursesValue = "";
        public DepartmentDirectory()
        {
            InitializeComponent();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            courseDataCollection = db.Collection("Department_Directory");
            LoadCoursesData();

        }

        private void DepartmentDirectory_Load(object sender, EventArgs e)
        {
            txtSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtSearch.Width, txtSearch.Height, 20, 20));

            txtEmail.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtEmail.Width, txtEmail.Height, 20, 20));

            dataGridView1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            dataGridView1.Width, dataGridView1.Height, 30, 30));

            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnAdd.Width, btnAdd.Height, 30, 30));

            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDelete.Width, btnDelete.Height, 30, 30));

            btnUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnUpdate.Width, btnUpdate.Height, 30, 30));

            txtDescription.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtDescription.Width, txtDescription.Height, 20, 20));

        }



        private async void btnAdd_Click(object sender, EventArgs e)
        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            var data = GetWriteData();

            if (string.IsNullOrEmpty(data.Courses))
            {
                MessageBox.Show("Please enter a valid value for Courses.");
                return;
            }

            // Check if a document with the same 'Courses' value exists
            var existingDoc = await db.Collection("Department_Directory")
                .WhereEqualTo("Courses", data.Courses)
                .GetSnapshotAsync();

            if (existingDoc.Documents.Count > 0)
            {
                // Document with the same 'Courses' already exists, handle accordingly
                MessageBox.Show("A document with the same Courses already exists.");
                return;
            }

            // Use the 'Courses' value as the document ID
            DocumentReference docRef = db.Collection("Department_Directory").Document(data.Courses);

            // Set the data for the document
            await docRef.SetAsync(data);

            MessageBox.Show("Course added successfully.");
            LoadCoursesData();
        }

        private Department_Directory GetWriteData()
        {
            string course = txtSearch.Text.Trim();
            string email = txtEmail.Text.Trim();
            string description = txtDescription.Text.Trim();

            return new Department_Directory()
            {
                Courses = course,
                Email = email,
                Description = description
            };

        }
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Check if there's a selected row
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected user from the selected row
                Department_Directory selectedCourse = (Department_Directory)dataGridView1.SelectedRows[0].DataBoundItem;

                // Populate the textboxes with the selected user's data
                txtSearch.Text = selectedCourse.Courses;
                txtEmail.Text = selectedCourse.Email;

                // Update the originalCoursesValue
                originalCoursesValue = selectedCourse.Courses;
            }
            else
            {
                // Clear the textboxes if no row is selected
                txtSearch.Text = "";
                txtEmail.Text = "";

                // Reset the originalCoursesValue
                originalCoursesValue = "";
            }
        }

        private async void LoadCoursesData()

        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            // Initialize Firestore database reference

            // Reference to the "Department_Directory" collection
            CollectionReference courseDataCollection = db.Collection("Department_Directory");

            // Create a query to retrieve all documents in the collection
            QuerySnapshot querySnapshot = await courseDataCollection.GetSnapshotAsync();

            // Create a list to store Department_Directory data
            List<Department_Directory> Courses = new List<Department_Directory>();

            // Loop through the documents and populate the Courses list
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                Department_Directory course = documentSnapshot.ConvertTo<Department_Directory>();

                if (course != null)
                {
                    Courses.Add(course);
                }
            }

            // Bind the list of courses to the DataGridView
            dataGridView1.DataSource = Courses;

            // Adjust column visibility and order
            // Assuming "Courses" is the name of the column you want to modify
            dataGridView1.Columns["Courses"].HeaderText = "Department Name";
            // Change the display order of 'Courses' column to the first position
            dataGridView1.Columns["Description"].DisplayIndex = 1; // Change the display order of 'Description' column to the second position
            dataGridView1.Columns["Email"].DisplayIndex = 2; // Change the display order of 'Email' column to the third position

            // Hide or show columns as needed
            dataGridView1.Columns["ID"].Visible = false; // Hide the 'ID' column
            dataGridView1.AutoResizeColumns();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private async Task<bool> EditCourse(string currentCourseName, string newCourseName)
        {
            try
            {
                // Find the document in Firestore based on the current course name
                var document = await courseDataCollection.Document(currentCourseName).GetSnapshotAsync();

                if (document.Exists)
                {
                    // Get the existing course data from Firestore
                    var existingCourseData = document.ConvertTo<Department_Directory>();

                    // Update the course's data with the new values
                    existingCourseData.Courses = newCourseName;

                    // Update the Firestore document with the updated course data
                    await courseDataCollection.Document(currentCourseName).SetAsync(existingCourseData);

                    return true; // Update successful
                }
                else
                {
                    return false; // Course not found
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                MessageBox.Show($"Error editing course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void btnUpdate_Click_1(object sender, EventArgs e)
        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;
            var data = GetWriteData();

            if (string.IsNullOrEmpty(data.Courses))
            {
                MessageBox.Show("Please enter a valid value for Courses.");
                return;
            }

            // Check if the 'Courses' value is being changed
            if (data.Courses != originalCoursesValue)
            {
                // Check if a document with the new 'Courses' value already exists
                var existingDoc = await db.Collection("Department_Directory")
                    .WhereEqualTo("Courses", data.Courses)
                    .GetSnapshotAsync();

                if (existingDoc.Documents.Count > 0)
                {
                    // Document with the same 'Courses' already exists, handle accordingly
                    MessageBox.Show("A document with the same Courses already exists.");
                    return;
                }
            }

            // Use the 'Courses' value as the new document ID
            DocumentReference docRef = db.Collection("Department_Directory").Document(data.Courses);

            // Set the data for the document
            await docRef.SetAsync(data);

            // Delete the old document (if 'Courses' value was changed)
            if (data.Courses != originalCoursesValue)
            {
                DocumentReference oldDocRef = db.Collection("Department_Directory").Document(originalCoursesValue);
                await oldDocRef.DeleteAsync();
            }

            MessageBox.Show("Course edited successfully.");
            LoadCoursesData();
        }


        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if there's a value in textBox1
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                MessageBox.Show("Please enter a value in textBox1.");
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Please enter a value in the Email textbox.");
                return;
            }

            // Get the value from textBox1 to determine which document to delete
            string courseToDelete = txtSearch.Text.Trim();

            // Initialize Firestore database reference
            var db = FirestoreHelper.Database;

            // Reference to the "Department_Directory" collection
            CollectionReference courseDataCollection = db.Collection("Department_Directory");

            // Create a query to retrieve the document with the specified 'Courses' value
            Query query = courseDataCollection.WhereEqualTo("Courses", courseToDelete).WhereEqualTo("Email", txtEmail.Text); ;

            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

            // Check if a document with the specified 'Courses' value exists
            if (querySnapshot.Count > 0)
            {
                // Get the first matching document
                var documentSnapshot = querySnapshot.Documents[0];

                // Delete the document
                await documentSnapshot.Reference.DeleteAsync();

                // Refresh the data in the DataGridView
                LoadCoursesData();

                MessageBox.Show("Document deleted successfully.");
            }
            else
            {
                MessageBox.Show("Document not found for deletion.");
            }
        }
    }
}
