using CAMPUS_NAVIGATION.Classes;
using Google.Cloud.Firestore;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace CAMPUS_NAVIGATION
{
    public partial class Notifications : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private bool formsVisible = false;
        private CollectionReference userDataCollection;
        private UserDataService userDataService = new UserDataService();
        private bool emailSentSuccessfully = false;
        private bool eventHandlerAttached = false; // Flag to track whether the event handler is attached
        public Notifications()
        {
            InitializeComponent();
        }

        private async void Notifications_Load(object sender, EventArgs e)
        {
            richTextBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            richTextBox1.Width, richTextBox1.Height, 30, 30));

            dataGridView1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            dataGridView1.Width, dataGridView1.Height, 30, 30));

            btnAddNotif.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnAddNotif.Width, btnAddNotif.Height, 30, 30));

            btnUpdate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnUpdate.Width, btnUpdate.Height, 30, 30));

            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));
            // Set the flag to false when the form is loaded
            emailSentSuccessfully = false;

            // Load user data asynchronously
            await LoadUserData();

            // Attach the event handler only once during form initialization
            if (!eventHandlerAttached)
            {
                btnAddNotif.Click += btnAddNotif_Click;
                eventHandlerAttached = true;
            }
        }



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radProfessor_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radSecurity_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SendEmailNotification(string toEmail, string subject, string body)
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

                            // After sending the email, store the data in Firebase
                            StoreEmailNotificationData(toEmail, subject, body);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Invalid email address: {toEmail}");
            }
        }
        private void StoreEmailNotificationData(string toEmail, string subject, string body)
        {
            try
            {
                // Initialize Firestore database reference
                FirestoreHelper.SetEnvironmentVariable();
                FirestoreDb db = FirestoreHelper.Database;

                // Reference to the "ZNotif" collection
                CollectionReference emailNotificationsCollection = db.Collection("ZNotif");

                // Create a new document with a unique identifier
                DocumentReference documentReference = emailNotificationsCollection.Document();

                // Create a new document with the email data
                var emailData = new
                {
                    Subject = subject,
                    Body = body,
                    Recipient = toEmail, // Use the toEmail directly
                    Timestamp = FieldValue.ServerTimestamp // You can use a timestamp for tracking when the email was sent
                };

                // Set the document data
                documentReference.SetAsync(emailData);
                // Show a success message
                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                radAll.Checked = false;
                richTextBox1.Text = "";
                return;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error storing email notification data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



        private bool isAddingNotification = false;
        private void btnAddNotif_Click(object sender, EventArgs e)
        {
            try
            {


                // Check which radio button is selected
                if (radAll.Checked)
                {
                    int i = 1;
                    // Send to all users
                    string message = richTextBox1.Text;

                    // Get all email addresses from the DataGridView
                    List<string> allEmails = dataGridView1.Rows
                        .Cast<DataGridViewRow>()
                        .Select(row => row.Cells["Email"].Value.ToString())
                        .ToList();

                    // Send email to all users
                    foreach (string emailAddress in allEmails)
                    {
                        SendEmailNotification(emailAddress, "Notification Subject", message);
                        if (i == 1)
                        {
                            radAll.Checked = false;
                            richTextBox1.Text = "";
                            emailSentSuccessfully = true; ; // Set the flag to true
                            break;
                        }
                    }
                }
                else if (radStudent.Checked)
                {
                    // Send to student role
                    int i = 1;
                    string message = richTextBox1.Text;

                    // Get the email addresses of students from the DataGridView
                    List<string> studentEmails = dataGridView1.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => row.Cells["Type"].Value.ToString() == "Student")
                        .Select(row => row.Cells["Email"].Value.ToString())
                        .ToList();

                    // Send email to students
                    foreach (string studentEmail in studentEmails)
                    {
                        SendEmailNotification(studentEmail, "Notification Subject", message);

                        if (i == 1)
                        {
                            radStudent.Checked = false;
                            richTextBox1.Text = "";
                            emailSentSuccessfully = true; ; // Set the flag to true
                            break;
                        }
                    }
                }
                else if (radProfessor.Checked)
                {
                    int i = 1;
                    // Send to professor role
                    string message = richTextBox1.Text;

                    // Get the email addresses of professors from the DataGridView
                    List<string> professorEmails = dataGridView1.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => row.Cells["Type"].Value.ToString() == "Professor")
                        .Select(row => row.Cells["Email"].Value.ToString())
                        .ToList();

                    // Send email to professors
                    foreach (string professorEmail in professorEmails)
                    {
                        SendEmailNotification(professorEmail, "Notification Subject", message);
                        if (i == 1)
                        {
                            radProfessor.Checked = false;
                            richTextBox1.Text = "";
                            emailSentSuccessfully = true; ; // Set the flag to true
                            break;
                        }
                    }
                }
                else if (radSecurity.Checked)
                {
                    int i = 1;
                    // Send to security role
                    string message = richTextBox1.Text;

                    // Get the email addresses of security personnel from the DataGridView
                    List<string> securityEmails = dataGridView1.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => row.Cells["Type"].Value.ToString() == "Security Guard")
                        .Select(row => row.Cells["Email"].Value.ToString())
                        .ToList();

                    // Send email to security personnel
                    foreach (string securityEmail in securityEmails)
                    {
                        SendEmailNotification(securityEmail, "Notification Subject", message);
                        if (i == 1)
                        {
                            radSecurity.Checked = false;
                            richTextBox1.Text = "";
                            emailSentSuccessfully = true; ; // Set the flag to true
                            break;
                        }
                    }
                }
                else if (radStaff.Checked)
                {
                    int i = 1;
                    // Send to staff role
                    string message = richTextBox1.Text;

                    // Get the email addresses of staff from the DataGridView
                    List<string> staffEmails = dataGridView1.Rows
                        .Cast<DataGridViewRow>()
                        .Where(row => row.Cells["Type"].Value.ToString() == "Staff")
                        .Select(row => row.Cells["Email"].Value.ToString())
                        .ToList();

                    // Send email to staff
                    foreach (string staffEmail in staffEmails)
                    {
                        SendEmailNotification(staffEmail, "Notification Subject", message);
                        if (i == 1)
                        {
                            radStaff.Checked = false;
                            richTextBox1.Text = "";
                            emailSentSuccessfully = true; ; // Set the flag to true
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a recipient type.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Your update logic goes here...

                // After the update, refresh the DataGridView
                LoadUserData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public async Task LoadUserData()
        {
            // Use the UserDataService to load user data
            List<UserData> users = await userDataService.LoadUserData();

            users = users.Where(user => user.Type != "Admin").ToList();
            // Bind the list of users to the DataGridView
            dataGridView1.DataSource = users;

            // Customize the DataGridView columns as needed
            // ...
            dataGridView1.Columns["Id"].Visible = false;
        }
        private List<UserData> FilterUsers(string nameToSearch, string idToSearch)
        {
            // Use the UserDataService to filter users
            List<UserData> originalUsers = userDataService.LoadUserData().Result;

            // Your existing filtering logic
            var filteredUsers = originalUsers.Where(user =>
                (string.IsNullOrEmpty(nameToSearch) || user.Name.Contains(nameToSearch, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(idToSearch) || user.InstitutionalID.Contains(idToSearch, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            return filteredUsers;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radStaff_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CloseNotif_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
