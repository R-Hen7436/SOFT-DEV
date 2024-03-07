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
using System.Net.Mail;
using System.Net;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CAMPUS_NAVIGATION
{
    public partial class CreateAccount : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private CollectionReference userDataCollection;
        private List<UserData> originalUsers = new List<UserData>();
        private BindingSource bindingSource = new BindingSource();
        private List<UserData> userDataList = new List<UserData>();
        private int x=0;

        public CreateAccount()
        {
            InitializeComponent();
            FirestoreHelper.SetEnvironmentVariable();
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            btnEnter.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnEnter.Width, btnEnter.Height, 30, 30));

            btnRegister.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnRegister.Width, btnRegister.Height, 30, 30));

            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));

            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel2.Width, panel2.Height, 30, 30));

            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel3.Width, panel3.Height, 30, 30));


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // Check if any of the textboxes is empty
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("PLEASE FILL IN ALL THE REQUIRED FIELDS BEFORE ADDING A USER.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Get the user data from the input fields
                UserData userData = GetWriteData();

                // Check if the email already exists in the DataGridView
                UserData existingUser = userDataList.FirstOrDefault(u => u.Email == userData.Email);

                if (existingUser != null)
                {
                    // Prompt the user to edit the email
                    string newEmail = PromptForNewEmail(existingUser.Email);

                    if (!string.IsNullOrEmpty(newEmail))
                    {
                        // Update the existing user's email
                        existingUser.Email = newEmail;

                        // Refresh the DataGridView
                        bindingSource.ResetBindings(false);
                    }
                }
                else
                {
                    // Add the user data to the list
                    userDataList.Add(userData);

                    // Refresh the DataGridView
                    bindingSource.DataSource = userDataList;
                    dataGridView1.DataSource = bindingSource;

                    // Hide the "ID" column
                    if (dataGridView1.Columns.Contains("ID"))
                    {
                        dataGridView1.Columns["ID"].Visible = false;
                    }
                }
            }
        }

        private string PromptForNewEmail(string currentEmail)
        {
            // Prompt the user to enter a new email
            string newEmail = Interaction.InputBox($"The email '{currentEmail}' already exists. Please enter a new email:", "Email Conflict", "");

            // Validate the new email
            if (IsValidEmail(newEmail))
            {
                // Check if the new email already exists in the DataGridView
                if (userDataList.Any(u => u.Email == newEmail))
                {
                    DialogResult result = MessageBox.Show("The entered email already exists in the list. Please enter a unique email.", "Email Conflict", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        // User clicked OK, prompt for a new email
                        return PromptForNewEmail(currentEmail); // Recursive call to prompt again
                    }
                    else
                    {
                        // User clicked Cancel, close the message box and return null
                        return null;
                    }
                }

                return newEmail;
            }
            else
            {
                DialogResult result = MessageBox.Show("Invalid email address. Please enter a valid email.", "Invalid Email", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(result == DialogResult.OK)
                {
                    return PromptForNewEmail(currentEmail);
                }
                else
                {
                    return null;
                }
                 // Recursive call to prompt again using the current email
            }
        }

        private string PromptForNewInstitutionalID(string currentInstitutionalID)
        {
            // Prompt the user to enter a new institutional ID
            string newInstitutionalID = Interaction.InputBox($"The institutional ID '{currentInstitutionalID}' already exists. Please enter a new institutional ID:", "Institutional ID Conflict", "");

            // Validate the new institutional ID
            if (!string.IsNullOrEmpty(newInstitutionalID))
            {
                // Check if the new institutional ID already exists in the DataGridView
                if (userDataList.Any(u => u.InstitutionalID == newInstitutionalID))
                {
                    DialogResult result = MessageBox.Show("The entered institutional ID already exists in the list. Please enter a unique institutional ID.", "Institutional ID Conflict", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        // User clicked OK, prompt for a new institutional ID
                        return PromptForNewInstitutionalID(currentInstitutionalID); // Recursive call to prompt again
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        return (null);
                    }

                }

                return newInstitutionalID;
            }
            else
            {
                DialogResult result = MessageBox.Show("Invalid institutional ID. Please enter a valid institutional ID.", "Invalid Institutional ID", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                if(result==DialogResult.OK)
                {
                    return PromptForNewInstitutionalID(currentInstitutionalID);
                }
                else
                {
                    return null; 
                }
                 // Recursive call to prompt again using the current institutional ID
            }
        }

        private UserData GetWriteData()
        {

            string name = textBox2.Text.Trim();
            string institutionalid = textBox1.Text.Trim();
            string password = Security.Encrypt(textBox4.Text);
            string email = textBox3.Text.Trim();
            string type = comboBox1.Text.Trim();
            string securityID = textBox4.Text.Trim(); // Store the password as securityID (unencrypted)

            return new UserData()
            {
                Name = name,
                InstitutionalID = institutionalid,
                Password = password,
                Email = email,
                Type = type,
                SecurityID = securityID // Store the password in the SecurityID field
            };
        }
        private bool CheckifUserAlreadyExist(string email)
        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Create a query to check if a document with the provided email exists
            Query query = db.Collection("UserData").WhereEqualTo("Email", email);

            QuerySnapshot querySnapshot = query.GetSnapshotAsync().Result;

            return querySnapshot.Count > 0;

        }
        private bool CheckifUserAlreadyExistByInstitutionalID(string institutionalID)
        {
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Create a query to check if a document with the provided institutionalID exists
            Query query = db.Collection("UserData").WhereEqualTo("InstitutionalID", institutionalID);

            QuerySnapshot querySnapshot = query.GetSnapshotAsync().Result;

            return querySnapshot.Count > 0;
        }

        private async void LoadUserData()
        {

            // Initialize Firestore database reference
            FirestoreHelper.SetEnvironmentVariable();
            FirestoreDb db = FirestoreHelper.Database;

            // Reference to the "UserData" collection
            userDataCollection = db.Collection("UserData");

            // Create a query to retrieve all users
            QuerySnapshot querySnapshot = await userDataCollection.GetSnapshotAsync();

            // Create a list to store user data
            List<UserData> users = new List<UserData>();
            originalUsers = users;

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
            originalUsers = users;

            // Bind the list of users to the DataGridView
            dataGridView1.DataSource = users;

            dataGridView1.Columns["ID"].Visible = false;

            // Customize the DataGridView columns to display specific properties
            dataGridView1.Columns["Password"].Visible = true; // Make the Password column visible
            dataGridView1.Columns["Email"].DisplayIndex = 2;
            dataGridView1.Columns["InstitutionalID"].DisplayIndex = 0;
            dataGridView1.Columns["Name"].DisplayIndex = 1;
            dataGridView1.Columns["Type"].DisplayIndex = 3;
            dataGridView1.AutoResizeColumns();
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Use a regular expression to validate the email format
                var regex = new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        private bool SendEmailNotification(string toEmail, string subject, string body)
        {
            if (IsValidEmail(toEmail))
            {
                try
                {
                    string smtpServer = "smtp.gmail.com";
                    int smtpPort = 587;
                    string smtpUsername = "extrahamham@gmail.com";
                    string smtpPassword = "cbwk pqay aknx tzow";

                    using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                        using (MailMessage mailMessage = new MailMessage(smtpUsername, toEmail, subject, body))
                        {
                            mailMessage.IsBodyHtml = false;
                            client.Send(mailMessage);

                            // Log the result
                            Console.WriteLine($"Email sent successfully to {toEmail}");

                            // Return true since the email was sent successfully
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the error
                    Console.WriteLine($"Error sending email: {ex.Message}");

                    MessageBox.Show($"Error sending email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Show a message if the email is not valid
                MessageBox.Show($"Invalid email address: {toEmail}", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Return false if the email was not sent successfully or the email is invalid
            return false;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("PLEASE USE THE 'ENTER' BUTTON TO INPUT DATA INTO THE DATAGRIDVIEW BEFORE REGISTERING A NEW USER.", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FirestoreDb db = FirestoreHelper.Database;

                var data = GetWriteData();

                // Check if the email is valid
                if (!IsValidEmail(data.Email))
                {
                    MessageBox.Show("INVALID EMAIL ADDRESS. PLEASE ENTER A VALID EMAIL.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the email already exists in Firestore
                if (CheckifUserAlreadyExist(data.Email))
                {
                    // Show the "Duplicate Email" message box
                    MessageBox.Show("An account with the same email already exists.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Prompt the user to enter a new email
                    string newEmail = PromptForNewEmail(data.Email);

                    if (!string.IsNullOrEmpty(newEmail))
                    {
                        // Update the user's email with the new one
                        data.Email = newEmail;
                    }
                    else
                    {
                        // User canceled the operation
                        return;
                    }
                }

                // Check if the institutionalID already exists in Firestore
                if (CheckifUserAlreadyExistByInstitutionalID(data.InstitutionalID))
                {
                    // Show the "Duplicate Institutional ID" message box
                    MessageBox.Show("An account with the same institutional ID already exists.", "Duplicate Institutional ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Prompt the user to enter a new institutional ID
                    string newInstitutionalID = PromptForNewInstitutionalID(data.InstitutionalID);

                    if (!string.IsNullOrEmpty(newInstitutionalID))
                    {
                        // Update the user's institutional ID with the new one
                        data.InstitutionalID = newInstitutionalID;
                    }
                    else
                    {
                        // User canceled the operation
                        return;
                    }
                }


                // Use the SendEmailNotification method to send the welcome email and check if it was sent successfully
                bool emailSentSuccessfully = SendEmailNotification(data.Email, "Welcome to CampusNav!", $"Dear {data.Name},\n\nWelcome to CampusNav! Thank you for creating an account.");

                // Continue with the account creation only if the email was sent successfully
                if (emailSentSuccessfully)
                {
                    DocumentReference docRef = db.Collection("UserData").Document();
                    data.ID = docRef.Id;
                    await docRef.SetAsync(data);

                    // Clear the textboxes
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    comboBox1.SelectedIndex = -1;

                    // Clear the DataGridView
                    userDataList.Clear();
                    bindingSource.DataSource = null;
                    dataGridView1.DataSource = null;

                    // Repopulate the DataGridView with the current data
                    bindingSource.DataSource = userDataList;
                    dataGridView1.DataSource = bindingSource;

                    // Display a success message
                    MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Display a message that account creation was cancelled due to an invalid email
                    MessageBox.Show("Account creation was cancelled due to an invalid email.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error during account creation: {ex.Message}");

                // Display an error message
                MessageBox.Show($"An error occurred during account creation. Please try again.\nError details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Clear the DataGridView
                userDataList.Clear();
                bindingSource.DataSource = null;
                dataGridView1.DataSource = null;
            }
        }

        private async Task<bool> SendEmailNotificationAsync(string toEmail, string subject, string body)
        {
            return await Task.Run(() => SendEmailNotification(toEmail, subject, body));
        }


        private void cbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowAll.Checked)
            {
                // If the checkbox is checked, load all user data
                LoadUserData();
            }
            else
            {
                // If the checkbox is unchecked, hide the data
                dataGridView1.DataSource = null;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}