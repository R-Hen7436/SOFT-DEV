using CAMPUS_NAVIGATION.Classes;
using Google.Cloud.Firestore;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace CAMPUS_NAVIGATION
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnLogin.Width, btnLogin.Height, 30, 30));

            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(w, h);
            this.Size = new Size(w, h);

            //label4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            //label4.Width, label4.Height, 10, 10));

            //label5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            //label5.Width, label5.Height, 10, 10));
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string inputID = txtID.Text;
            string inputPassword = txtPassword.Text;

            try
            {
                FirestoreHelper.SetEnvironmentVariable();

                // Check if the input ID and password are both "admin"
                if (inputID == "admin" && inputPassword == "admin")
                {
                    // Redirect to the Admin form
                    Admin adminForm = new Admin();
                    adminForm.Show();
                    this.Hide();
                    return;
                }

                // Query Firestore for a user with the provided ID
                FirestoreDb database = FirestoreHelper.Database;

                if (database == null)
                {
                    MessageBox.Show("Firestore database is not configured.");
                    return;
                }

                CollectionReference usersCollection = database.Collection("UserData");
                QuerySnapshot querySnapshot = await usersCollection
                    .WhereEqualTo("InstitutionalID", inputID)
                    .Limit(1)
                    .GetSnapshotAsync();

                if (querySnapshot.Count == 0)
                {
                    MessageBox.Show("User not found.");
                    return;
                }

                // Retrieve the user data
                UserData userData = querySnapshot[0].ConvertTo<UserData>();

                // Decrypt the stored password and verify
                string decryptedPassword = Security.Decrypt(userData.Password);

                if (inputPassword == decryptedPassword)
                {
                    // Login successful, retrieve user type
                    string userType = userData.Type;

                    // Perform actions based on user type
                    if (userType == "Admin")
                    {
                        // Redirect to the Admin form
                        Admin adminForm = new Admin();
                        adminForm.Show();
                    }
                    else if (userType == "Security Guard")
                    {
                        // Redirect to the SecurityGuard form
                        SecurityGuard securityForm = new SecurityGuard();
                        securityForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid user type.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void pctExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pctGIF_Click(object sender, EventArgs e)
        {
            //pctGIF.BringToFront();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGuest_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void pctHide_Click(object sender, EventArgs e)
        {

        }

        private void pctShow_Click(object sender, EventArgs e)
        {

        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }
    }
}