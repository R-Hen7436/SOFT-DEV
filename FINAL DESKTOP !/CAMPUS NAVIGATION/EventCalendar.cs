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
using static System.Windows.Forms.ImageList;
using System.Xml.Linq;
using CAMPUS_NAVIGATION.Classes;

namespace CAMPUS_NAVIGATION
{
    public partial class EventCalendar : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private FirestoreDb db;
        private CollectionReference imagesCollection;

        private void ClearControls()
        {
            // Clear the PictureBox and TextBox
            pctCalender.Image = null;
            txtNAMEImage.Clear();
            txtIDImage.Clear();
        }
        public EventCalendar()
        {
            InitializeComponent();
            // Initialize Firestore database and collection
            db = FirestoreDb.Create("authentication-v1-4e63f"); // Replace with your Firestore project ID
            imagesCollection = db.Collection("images");
            pctCalender.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void EventCalendar_Load(object sender, EventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));

            pctCalender.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            pctCalender.Width, pctCalender.Height, 30, 30));

            txtIDImage.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtIDImage.Width, txtIDImage.Height, 20, 20));

            txtNAMEImage.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            txtNAMEImage.Width, txtIDImage.Height, 20, 20));

            btnBrowse.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnBrowse.Width, btnBrowse.Height, 30, 30));

            btnRetrieve.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnRetrieve.Width, btnRetrieve.Height, 30, 30));

            btnInsert.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnInsert.Width, btnInsert.Height, 30, 30));

            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDelete.Width, btnDelete.Height, 30, 30));

            btnUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnUpdate.Width, btnUpdate.Height, 30, 30));
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image originalImage = new Bitmap(openFileDialog.FileName);
                    pctCalender.Image = ResizeImage(originalImage, pctCalender.Width, pctCalender.Height);
                }
            }
        }
        private Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            // Calculate the new dimensions to maintain the aspect ratio
            int newWidth, newHeight;
            double aspectRatio = (double)image.Width / image.Height;

            if (image.Width > image.Height)
            {
                newWidth = maxWidth;
                newHeight = (int)(newWidth / aspectRatio);
            }
            else
            {
                newHeight = maxHeight;
                newWidth = (int)(newHeight * aspectRatio);
            }

            // Create a new bitmap with the new dimensions
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);
            using (Graphics gr = Graphics.FromImage(resizedImage))
            {
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gr.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (pctCalender.Image != null)
            {
                string imageName = txtNAMEImage.Text; // Get the user-provided name
                string imageID = txtIDImage.Text; // Get the user-provided ID
                byte[] imageData; // Get the image data from pictureBox1

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    pctCalender.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }

                try
                {
                    // Check if an image with the same name already exists
                    QuerySnapshot nameQuerySnapshot = await imagesCollection.WhereEqualTo("Name", imageName).GetSnapshotAsync();
                    if (nameQuerySnapshot.Count > 0)
                    {
                        MessageBox.Show("An image with the same name already exists. Please use a different name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Stop the insert process
                    }

                    // Check if an image with the same ID already exists
                    QuerySnapshot idQuerySnapshot = await imagesCollection.WhereEqualTo("ID", imageID).GetSnapshotAsync();
                    if (idQuerySnapshot.Count > 0)
                    {
                        MessageBox.Show("An image with the same ID already exists. Please use a different ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Stop the insert process
                    }

                    // Create an instance of Image_Modal with the user-provided ID and name
                    var image = new Image_Modal
                    {
                        Img = Convert.ToBase64String(imageData),
                        Name = imageName,
                        ID = imageID
                    };

                    // Add the image to Firestore
                    await InsertImageToFirestore(image);

                    // Clear the controls
                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting image: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select an image first.");
            }
        }

        private async Task InsertImageToFirestore(Image_Modal image)
        {
            try
            {
                // Add the image to Firestore with an explicitly set document ID
                DocumentReference docRef = imagesCollection.Document(image.Name);
                await docRef.SetAsync(image);

                MessageBox.Show("Image inserted with ID: " + image.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting image: " + ex.Message);
            }
        }

        private async void btnRetrieve_Click(object sender, EventArgs e)
        {
            string imageName = txtNAMEImage.Text; // Get the image name from the TextBox

            if (!string.IsNullOrEmpty(imageName))
            {
                try
                {
                    QuerySnapshot querySnapshot = await imagesCollection.WhereEqualTo("Name", imageName).GetSnapshotAsync();

                    if (querySnapshot.Count == 1)
                    {
                        DocumentSnapshot documentSnapshot = querySnapshot.Documents[0];

                        // Retrieve the ID, Image, and Name from the Firestore document
                        string imageID = documentSnapshot.Id;
                        Image_Modal retrievedImage = documentSnapshot.ConvertTo<Image_Modal>();
                        string retrievedName = retrievedImage.Name;
                        string retrievedId = retrievedImage.ID;

                        // Set the retrieved "ID" in the txtID textbox
                        txtIDImage.Text = retrievedId;

                        // Convert the base64 string back to a byte array
                        byte[] imageData = Convert.FromBase64String(retrievedImage.Img);

                        // Create an image from the byte array and display it in pictureBox1
                        using (MemoryStream memoryStream = new MemoryStream(imageData))
                        {
                            pctCalender.Image = Image.FromStream(memoryStream);
                        }

                        // Set the original name and ID in the Tag property for later use
                        txtNAMEImage.Tag = retrievedName;
                        txtIDImage.Tag = retrievedId;

                        // Optionally, display or use the retrieved ID, Image, and Name as needed
                        MessageBox.Show($"Retrieved ID: {imageID}, Name: {retrievedName}");
                    }
                    else if (querySnapshot.Count > 1)
                    {
                        MessageBox.Show("Multiple images with the same name found in Firestore. Please ensure names are unique.");
                    }
                    else
                    {
                        MessageBox.Show("Image with the specified name not found in Firestore.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving image: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter an image name to retrieve.");
            }
        }
        private async Task<bool> IsNameTaken(string name)
        {
            try
            {
                QuerySnapshot querySnapshot = await imagesCollection.WhereEqualTo("Name", name).GetSnapshotAsync();
                return querySnapshot.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking if the name is taken: " + ex.Message);
                return true; // Assume the name is taken to prevent unintentional overwrites
            }
        }
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string imageName = txtNAMEImage.Text; // Get the image name from the TextBox

            if (!string.IsNullOrEmpty(imageName))
            {
                try
                {
                    QuerySnapshot querySnapshot = await imagesCollection.WhereEqualTo("Name", imageName).GetSnapshotAsync();

                    if (querySnapshot.Count == 1)
                    {
                        DocumentSnapshot documentSnapshot = querySnapshot.Documents[0];
                        DocumentReference docRef = documentSnapshot.Reference;

                        // Proceed with deletion
                        await docRef.DeleteAsync();
                        MessageBox.Show("Image deleted from Firestore.");
                        ClearControls();
                    }
                    else if (querySnapshot.Count > 1)
                    {
                        MessageBox.Show("Multiple images with the same name found in Firestore. Please ensure names are unique.");
                    }
                    else
                    {
                        MessageBox.Show("Image with the specified name not found in Firestore.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting image: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter an image name to delete.");
            }
        }
        private async Task UpdateImageInFirestore(string imageID, string newName, string newID, Image updatedImage)
        {
            try
            {
                // Query Firestore to find the document with the specified "imageID"
                QuerySnapshot querySnapshot = await imagesCollection.WhereEqualTo("ID", imageID).GetSnapshotAsync();

                if (querySnapshot.Count == 1)
                {
                    // Get the document reference for the existing image
                    DocumentSnapshot documentSnapshot = querySnapshot.Documents[0];
                    DocumentReference docRef = documentSnapshot.Reference;

                    // Convert the updated image to a byte array if it's not null
                    byte[] updatedImageData = null;
                    if (updatedImage != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            updatedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            updatedImageData = ms.ToArray();
                        }
                    }

                    // Create an update dictionary to hold the changes
                    Dictionary<string, object> updateData = new Dictionary<string, object>();

                    // Check if the updated name is different from the current name
                    string currentName = documentSnapshot.ConvertTo<Image_Modal>().Name;
                    if (currentName != newName)
                    {
                        updateData["Name"] = newName; // Update the name if it's different
                    }

                    // Check if the updated ID is different from the current ID
                    string currentID = documentSnapshot.ConvertTo<Image_Modal>().ID;
                    if (currentID != newID)
                    {
                        updateData["ID"] = newID; // Update the ID if it's different
                    }

                    // Check if the image is updated
                    if (updatedImageData != null)
                    {
                        updateData["Img"] = Convert.ToBase64String(updatedImageData); // Update the image if it's not null
                    }

                    // Update the data in the Firestore document if there are changes
                    if (updateData.Any())
                    {
                        await docRef.UpdateAsync(updateData);
                        MessageBox.Show("Image updated in Firestore.");
                    }
                    else
                    {
                        MessageBox.Show("No changes detected. Please provide a new name, ID, or image for the update.");
                    }
                }
                else
                {
                    MessageBox.Show("Image with the specified ID not found in Firestore.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating image: " + ex.Message);
            }
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the updated name and image from the TextBox and PictureBox
            string updatedName = txtNAMEImage.Text;
            string updatedID = txtIDImage.Text;
            string imageID = txtIDImage.Tag?.ToString(); // Retrieve the original ID from the Tag property
            Image updatedImage = pctCalender.Image;

            // Retrieve the original name and ID from the Tag property
            string originalName = txtNAMEImage.Tag?.ToString();
            string originalID = txtIDImage.Tag?.ToString();

            // If the user has not provided a new name or ID, retain the original name and ID
            if (string.IsNullOrEmpty(updatedName))
            {
                updatedName = originalName;
            }
            if (string.IsNullOrEmpty(updatedID))
            {
                updatedID = originalID;
            }

            // Update the image in Firestore using the provided "ID" to locate the document
            await UpdateImageInFirestore(originalID, updatedName, updatedID, updatedImage);

            // Clear controls after the update
            ClearControls();
        }
    }
}