using CAMPUS_NAVIGATION.Classes;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
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
    public partial class SecurityGuard : Form
    {
        private const string NGE_AREA = "NGE";
        private const string RTL_AREA = "RTL";
        private const string ALLIED_AREA = "ALLIED"; // Add your area names here
        private const string SHS_AREA = "SHS";       // Add your area names here
        private const string STUDY_AREA = "STUDY";   // Add your area names here
        private const string GLE_AREA = "GLE";       // Add your area names here

        private FirestoreDb firestoreDb;
        private CollectionReference overallDataCollection;
        private System.Windows.Forms.Timer updateTimer;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private CollectionReference userDataCollection;
        private List<UserData> originalUsers = new List<UserData>();
        private bool formsVisible = false;

        public SecurityGuard()
        {
            InitializeComponent();
            FirestoreHelper.SetEnvironmentVariable();
            InitializeFirestore();
            InitializeMainParkingData(NGE_AREA);
            InitializeMainParkingData(RTL_AREA);
            InitializeMainParkingData(ALLIED_AREA);
            InitializeMainParkingData(SHS_AREA);
            InitializeMainParkingData(STUDY_AREA);
            InitializeMainParkingData(GLE_AREA);

            InitializeUpdateTimer();
           
            FetchAndDisplayParkingData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SecurityGuard_Load(object sender, EventArgs e)
        {
            label1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            label1.Width, label1.Height, 30, 30));

            textBoxNGEMainParkingValue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBoxNGEMainParkingValue.Width, textBoxNGEMainParkingValue.Height, 20, 20));

            textBoxRTLMainParkingValue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBoxRTLMainParkingValue.Width, textBoxRTLMainParkingValue.Height, 20, 20));

            textBoxALLIEDMainParkingValue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBoxALLIEDMainParkingValue.Width, textBoxALLIEDMainParkingValue.Height, 20, 20));

            textBoxSHSMainParkingValue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBoxSHSMainParkingValue.Width, textBoxSHSMainParkingValue.Height, 20, 20));

            textBoxSTUDYMainParkingValue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBoxSTUDYMainParkingValue.Width, textBoxSTUDYMainParkingValue.Height, 20, 20));

            textBoxGLEMainParkingValue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            textBoxGLEMainParkingValue.Width, textBoxGLEMainParkingValue.Height, 20, 20));

            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel1.Width, panel1.Height, 30, 30));

            panel8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel8.Width, panel8.Height, 30, 30));

            panel9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel9.Width, panel9.Height, 30, 30));

            panel10.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel10.Width, panel10.Height, 30, 30));

            panel11.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel11.Width, panel11.Height, 30, 30));

            panel12.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            panel12.Width, panel12.Height, 30, 30));


            pictureBox3.Show();

            pctNGE.Hide();
            pctRTL.Hide();
            pctALLIED.Hide();
            pctSHS.Hide();
            pctSTUDY.Hide();
            pctGLE.Hide();
        }
      
        private void TogglePanelWidth(Panel panel)
        {
            panel.Width = (panel.Width == 196) ? 350 : 196;
        }
        private async void btnNGE_Click(object sender, EventArgs e)
        {
            if (panel2.Width == 196)
            {
                panel2.Width = 350;
            }
            else
            {
                panel2.Width = 196;
            }

            //pictureBox3.Hide();

            //pctNGE.Hide();
            //pctALLIED.Hide();
            //pctSHS.Hide();
            //pctSTUDY.Hide();
            //pctGLE.Hide();

            //pctRTL.Show();
            //pctRTL.BringToFront();

            if (formsVisible)
            {
                pictureBox3.Show();

                pctRTL.Hide();
                pctALLIED.Hide();
                pctSHS.Hide();
                pctSTUDY.Hide();
                pctGLE.Hide();
                pctNGE.Hide();
                formsVisible = false;
            }
            else
            {
                pictureBox3.Hide();

                pctRTL.Hide();
                pctALLIED.Hide();
                pctSHS.Hide();
                pctSTUDY.Hide();
                pctGLE.Hide();

                pctNGE.Show();
                pctNGE.BringToFront();
                formsVisible = true;
            }
        }
    

        private void btnRTL_Click(object sender, EventArgs e)
        {
            if (panel3.Width == 196)
            {
                panel3.Width = 350;
            }
            else
            {
                panel3.Width = 196;
            }

            //pictureBox3.Hide();

            //pctNGE.Hide();
            //pctALLIED.Hide();
            //pctSHS.Hide();
            //pctSTUDY.Hide();
            //pctGLE.Hide();

            //pctRTL.Show();
            //pctRTL.BringToFront();

            if (formsVisible)
            {
                pictureBox3.Show();

                pctRTL.Hide();
                pctALLIED.Hide();
                pctSHS.Hide();
                pctSTUDY.Hide();
                pctGLE.Hide();
                pctNGE.Hide();
                formsVisible = false;
            }
            else
            {
                pictureBox3.Hide();

                pctNGE.Hide();
                pctALLIED.Hide();
                pctSHS.Hide();
                pctSTUDY.Hide();
                pctGLE.Hide();

                pctRTL.Show();
                pctRTL.BringToFront();
                formsVisible = true;
            }
        }

        private void btnALLIED_Click(object sender, EventArgs e)
        {
            if (panel4.Width == 196)
            {
                panel4.Width = 350;
            }
            else
            {
                panel4.Width = 196;
            }

            //pictureBox3.Hide();

            //pctNGE.Hide();
            //pctRTL.Hide();
            //pctSHS.Hide();
            //pctSTUDY.Hide();
            //pctGLE.Hide();

            //pctALLIED.Show();
            //pctALLIED.BringToFront();

            if (formsVisible)
            {
                pictureBox3.Show();

                pctRTL.Hide();
                pctALLIED.Hide();
                pctSHS.Hide();
                pctSTUDY.Hide();
                pctGLE.Hide();
                pctNGE.Hide();
                formsVisible = false;
            }
            else
            {
                pictureBox3.Hide();

                pctNGE.Hide();
                pctRTL.Hide();
                pctSHS.Hide();
                pctSTUDY.Hide();
                pctGLE.Hide();

                pctALLIED.Show();
                pctALLIED.BringToFront();
                formsVisible = true;
            }
        }

        private void btnSHS_Click(object sender, EventArgs e)
        {
            if (panel5.Width == 196)
            {
                panel5.Width = 350;
            }
            else
            {
                panel5.Width = 196;
            }

            //pictureBox3.Hide();

            //pctNGE.Hide();
            //pctRTL.Hide();
            //pctALLIED.Hide();
            //pctSTUDY.Hide();
            //pctGLE.Hide();

            //pctSHS.Show();
            //pctSHS.BringToFront();

            if (formsVisible)
            {
                pictureBox3.Show();

                pctRTL.Hide();
                pctALLIED.Hide();
                pctSHS.Hide();
                pctSTUDY.Hide();
                pctGLE.Hide();
                pctNGE.Hide();
                formsVisible = false;
            }
            else
            {
                pictureBox3.Hide();

                pctNGE.Hide();
                pctRTL.Hide();
                pctALLIED.Hide();
                pctSTUDY.Hide();
                pctGLE.Hide();

                pctSHS.Show();
                pctSHS.BringToFront();
                formsVisible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (panel6.Width == 196)
            {
                panel6.Width = 350;
            }
            else
            {
                panel6.Width = 196;
            }

            //pictureBox3.Hide();

            //pctNGE.Hide();
            //pctRTL.Hide();
            //pctALLIED.Hide();
            //pctSHS.Hide();
            //pctGLE.Hide();

            //pctSTUDY.Show();
            //pctSTUDY.BringToFront();

            if (formsVisible)
            {
                pictureBox3.Show();

                pctRTL.Hide();
                pctALLIED.Hide();
                pctSHS.Hide();
                pctSTUDY.Hide();
                pctGLE.Hide();
                pctNGE.Hide();
                formsVisible = false;
            }
            else
            {
                pictureBox3.Hide();

                pctNGE.Hide();
                pctRTL.Hide();
                pctALLIED.Hide();
                pctSHS.Hide();
                pctGLE.Hide();

                pctSTUDY.Show();
                pctSTUDY.BringToFront();
                formsVisible = true;
            }
        }

        private void btnGLE_Click(object sender, EventArgs e)
        {
            if (panel7.Width == 196)
            {
                panel7.Width = 350;
            }
            else
            {
                panel7.Width = 196;
            }

            //pictureBox3.Hide();

            //pctNGE.Hide();
            //pctRTL.Hide();
            //pctALLIED.Hide();
            //pctSHS.Hide();
            //pctSTUDY.Hide();

            //pctGLE.Show();
            //pctGLE.BringToFront();

            if (formsVisible)
            {
                pictureBox3.Show();

                pctRTL.Hide();
                pctALLIED.Hide();
                pctSHS.Hide();
                pctSTUDY.Hide();
                pctGLE.Hide();
                pctNGE.Hide();
                formsVisible = false;
            }
            else
            {
                pictureBox3.Hide();

                pctNGE.Hide();
                pctRTL.Hide();
                pctALLIED.Hide();
                pctSHS.Hide();
                pctSTUDY.Hide();

                pctGLE.Show();
                pctGLE.BringToFront();
                formsVisible = true;
            }
        }

        private void textBoxNGEMainParkingValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxALLIEDMainParkingValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSHSMainParkingValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSTUDYMainParkingValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxGLEMainParkingValue_TextChanged(object sender, EventArgs e)
        {

        }

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
        //    Form1 form = new Form1();
        //    form.Show();
        //}

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void InitializeFirestore()
        {
            string projectId = "authentication-v1-4e63f"; // Your Firestore project ID
            FirestoreDbBuilder builder = new FirestoreDbBuilder
            {
                ProjectId = projectId,
            };
            firestoreDb = builder.Build();
        }

        private void InitializeMainParkingData(string parkingArea)
        {
            overallDataCollection = firestoreDb.Collection("OverallData");

            // Reference to the specified parking area document
            DocumentReference parkingAreaDocRef = overallDataCollection.Document(parkingArea);

            // Check if the document already exists
            DocumentSnapshot snapshot = parkingAreaDocRef.GetSnapshotAsync().Result;

            if (!snapshot.Exists)
            {
                // Document doesn't exist, create it with an initial value of 0
                var data = new { value = 0 };
                parkingAreaDocRef.SetAsync(data).Wait();
            }
        }

        private void FetchAndDisplayParkingData()
        {
            UpdateTextBoxValue(NGE_AREA, GetParkingValue(NGE_AREA));
            UpdateTextBoxValue(RTL_AREA, GetParkingValue(RTL_AREA));
            UpdateTextBoxValue(ALLIED_AREA, GetParkingValue(ALLIED_AREA));
            UpdateTextBoxValue(SHS_AREA, GetParkingValue(SHS_AREA));
            UpdateTextBoxValue(STUDY_AREA, GetParkingValue(STUDY_AREA));
            UpdateTextBoxValue(GLE_AREA, GetParkingValue(GLE_AREA));
        }

        private int GetParkingValue(string area)
        {
            DocumentSnapshot snapshot = GetParkingDocumentRef(area).GetSnapshotAsync().Result;

            if (snapshot.Exists)
            {
                return snapshot.GetValue<int>("value");
            }
            return 0; // Return 0 if the document doesn't exist
        }

        private DocumentReference GetParkingDocumentRef(string area)
        {
            return overallDataCollection.Document(area);
        }

        private void UpdateTextBoxValue(string area, int currentValue)
        {
            int maximumCapacity = GetMaximumCapacityForArea(area); // Get the maximum capacity based on the area
            TextBox textBox = GetTextBoxForArea(area);
            string text = $"{currentValue}/{maximumCapacity}";
            textBox.Text = text;
        }

        private TextBox GetTextBoxForArea(string area)
        {
            switch (area)
            {
                case NGE_AREA:
                    return textBoxNGEMainParkingValue;
                case RTL_AREA:
                    return textBoxRTLMainParkingValue;
                case ALLIED_AREA:
                    return textBoxALLIEDMainParkingValue;
                case SHS_AREA:
                    return textBoxSHSMainParkingValue;
                case STUDY_AREA:
                    return textBoxSTUDYMainParkingValue;
                case GLE_AREA:
                    return textBoxGLEMainParkingValue;
                default:
                    throw new ArgumentException("Invalid parking area.");
            }
        }
        private void InitializeUpdateTimer()
        {
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += async (sender, e) => await UpdateTimer_Tick();
            updateTimer.Start();
        }

        private async Task UpdateTimer_Tick()
        {
            await Task.Run(() =>
            {
                // Fetch and display updated parking data in a background thread
                int ngeParkingValue = GetParkingValue(NGE_AREA);
                int rtlParkingValue = GetParkingValue(RTL_AREA);
                int alliedParkingValue = GetParkingValue(ALLIED_AREA);
                int shsParkingValue = GetParkingValue(SHS_AREA);
                int studyParkingValue = GetParkingValue(STUDY_AREA);
                int gleParkingValue = GetParkingValue(GLE_AREA);

                // Update UI controls in the UI thread
                BeginInvoke((Action)(() =>
                {
                    UpdateTextBoxValue(NGE_AREA, ngeParkingValue);
                    UpdateTextBoxValue(RTL_AREA, rtlParkingValue);
                    UpdateTextBoxValue(ALLIED_AREA, alliedParkingValue);
                    UpdateTextBoxValue(SHS_AREA, shsParkingValue);
                    UpdateTextBoxValue(STUDY_AREA, studyParkingValue);
                    UpdateTextBoxValue(GLE_AREA, gleParkingValue);
                }));
            });
        }
        private void ShowSuccessMessage(string action, string area, int newValue)
        {
            MessageBox.Show($"{action}ed a vehicle in {area} area. New count: {newValue}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AddOrDeductParkingCount(string area, int change)
        {
            // Initialize the specified parking area document
            InitializeMainParkingData(area);

            // Retrieve the current parking value from the database
            int currentValue = GetParkingValue(area);

            int maximumCapacity = GetMaximumCapacityForArea(area);

            // Calculate the new value with the specified change
            int newValue = currentValue + change;

            if (newValue >= 0 && newValue <= maximumCapacity)
            {
                // Update the value in the database
                GetParkingDocumentRef(area).SetAsync(new { value = newValue }).Wait();

                // Show a success message
                string action = change > 0 ? "Add" : "Delete";
                ShowSuccessMessage(action, area, newValue);
            }
            else
            {
                // Show an error message if the new value exceeds the maximum capacity
                ShowErrorMessage(area, maximumCapacity);
            }
        }

        private void CheckAndAddOrDeductParkingCount(string area, int change)
        {
            int maximumCapacity = GetMaximumCapacityForArea(area);
            int currentValue = GetParkingValue(area);

            if (currentValue == maximumCapacity && change > 0)
            {
                // Parking area is already full
                ShowFullMessage(area);
            }
            else
            {
                // Update the value in the database
                AddOrDeductParkingCount(area, change);
            }
        }
        private void ShowErrorMessage(string area, int maximumCapacity)
        {
            MessageBox.Show($"The {area} parking area is already full. Maximum capacity: {maximumCapacity}", "Parking Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void ShowFullMessage(string area)
        {
            MessageBox.Show($"The {area} parking area is already full.", "Parking Full", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private int GetMaximumCapacityForArea(string area)
        {
            switch (area)
            {
                case NGE_AREA:
                    return 18;
                case RTL_AREA:
                    return 25;
                case ALLIED_AREA:
                    return 30;
                case SHS_AREA:
                    return 50;
                case STUDY_AREA:
                    return 40;
                case GLE_AREA:
                    return 10;
                default:
                    return 0; // Default to 0 if the area is not recognized
            }
        }

        private void btnNGEadd_Click(object sender, EventArgs e)
        {
            Console.WriteLine("btnNGEadd_Click called");
            AddOrDeductParkingCount(NGE_AREA, 1);
        }

        private void btnNGEdel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("btnNGEdel_Click called");
            AddOrDeductParkingCount(NGE_AREA, -1);
        }

        private void btnRTLadd_Click(object sender, EventArgs e)
        {
            AddOrDeductParkingCount(RTL_AREA, 1);
        }

        private void btnRTLdel_Click(object sender, EventArgs e)
        {
            AddOrDeductParkingCount(RTL_AREA, -1);
        }

        private void btnALLIEDadd_Click(object sender, EventArgs e)
        {
            AddOrDeductParkingCount(ALLIED_AREA, 1);
        }

        private void btnALLIEDdel_Click(object sender, EventArgs e)
        {
            AddOrDeductParkingCount(ALLIED_AREA, -1);
        }

        private void btnSHSadd_Click(object sender, EventArgs e)
        {
            AddOrDeductParkingCount(SHS_AREA, 1);
        }

        private void btnSHSdel_Click(object sender, EventArgs e)
        {
            AddOrDeductParkingCount(SHS_AREA, -1);
        }

        private void btnSTUDYadd_Click(object sender, EventArgs e)
        {
            AddOrDeductParkingCount(STUDY_AREA, 1);
        }

        private void btnSTUDYdel_Click(object sender, EventArgs e)
        {
            AddOrDeductParkingCount(STUDY_AREA, -1);
        }

        private void btnGLEadd_Click(object sender, EventArgs e)
        {
            AddOrDeductParkingCount(GLE_AREA, 1);
        }

        private void btnGLEdel_Click(object sender, EventArgs e)
        {
            AddOrDeductParkingCount(GLE_AREA, -1);
        }

        private void pctGLE_Click(object sender, EventArgs e)
        {

        }
    }
}
