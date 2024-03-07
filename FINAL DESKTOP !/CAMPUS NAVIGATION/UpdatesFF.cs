using Google.Protobuf;
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
    public partial class UpdatesFF : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private bool formsVisible = false;

        public UpdatesFF()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Show();
                helpCenter1.BringToFront();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = true;
            }
        }

        private void UpdatesFF_Load(object sender, EventArgs e)
        {
            btnCampusServicesDirectory.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnCampusServicesDirectory.Width, btnCampusServicesDirectory.Height, 30, 30));

            btnDepartmentDirectory.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDepartmentDirectory.Width, btnDepartmentDirectory.Height, 30, 30));

            btnStudentOrgDirectory.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnStudentOrgDirectory.Width, btnStudentOrgDirectory.Height, 30, 30));

            btnEmergencyContacts.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnEmergencyContacts.Width, btnEmergencyContacts.Height, 30, 30));

            btnEventCalendar.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnEventCalendar.Width, btnEventCalendar.Height, 30, 30));

            btnHelpCenter.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnHelpCenter.Width, btnHelpCenter.Height, 30, 30));

            btnCampusTours.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnCampusTours.Width, btnCampusTours.Height, 30, 30));

            btnLostandFound.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnLostandFound.Width, btnLostandFound.Height, 30, 30));

            btnReco.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnReco.Width, btnReco.Height, 30, 30));

            departmentDirectory1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            departmentDirectory1.Width, departmentDirectory1.Height, 30, 30));

            campusServicesDirectory1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            campusServicesDirectory1.Width, campusServicesDirectory1.Height, 30, 30));

            campusTours1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            campusTours1.Width, campusTours1.Height, 30, 30));

            emergencyContacts1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            emergencyContacts1.Width, emergencyContacts1.Height, 30, 30));

            eventCalendar1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            eventCalendar1.Width, eventCalendar1.Height, 30, 30));

            helpCenter1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            helpCenter1.Width, helpCenter1.Height, 30, 30));

            lostandFound1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            lostandFound1.Width, lostandFound1.Height, 30, 30));

            recommendation1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            recommendation1.Width, recommendation1.Height, 30, 30));

            studentOrganizationDirectory1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            studentOrganizationDirectory1.Width, studentOrganizationDirectory1.Height, 30, 30));

            label1.Show();
            departmentDirectory1.Hide();
            campusServicesDirectory1.Hide();
            studentOrganizationDirectory1.Hide();
            emergencyContacts1.Hide();
            eventCalendar1.Hide();
            helpCenter1.Hide();
            campusTours1.Hide();
            lostandFound1.Hide();
            recommendation1.Hide();
        }

        private void btnDepartmentDirectory_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Show();
                departmentDirectory1.Show();
                departmentDirectory1.BringToFront();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = true;
            }
        }

        private void btnCampusServicesDirectory_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Show();
                campusServicesDirectory1.BringToFront();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = true;
            }
        }

        private void btnStudentOrgDirectory_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Show();
                studentOrganizationDirectory1.BringToFront();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = true;
            }
        }

        private void btnEmergencyContacts_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Show();
                emergencyContacts1.BringToFront();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = true;
            }
        }

        private void btnEventCalendar_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Show();
                eventCalendar1.BringToFront();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = true;
            }
        }

        private void btnCampusTours_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Show();
                campusTours1.BringToFront();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = true;
            }
        }

        private void btnLostandFound_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Show();
                lostandFound1.BringToFront();
                recommendation1.Hide();
                formsVisible = true;
            }
        }

        private void btnReco_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Show();
                departmentDirectory1.Hide();
                campusServicesDirectory1.Hide();
                studentOrganizationDirectory1.Hide();
                emergencyContacts1.Hide();
                eventCalendar1.Hide();
                helpCenter1.Hide();
                campusTours1.Hide();
                lostandFound1.Hide();
                recommendation1.Show();
                recommendation1.BringToFront();
                formsVisible = true;
            }
        }

        private void CloseFeedBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
