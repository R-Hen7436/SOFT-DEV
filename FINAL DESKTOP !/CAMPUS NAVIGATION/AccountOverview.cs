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
    public partial class AccountOverview : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);
        private bool formsVisible = false;

        public AccountOverview()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AccountOverview_Load(object sender, EventArgs e)
        {
            btnCreate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnCreate.Width, btnCreate.Height, 30, 30));

            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnDelete.Width, btnDelete.Height, 30, 30));

            btnSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnSearch.Width, btnSearch.Height, 30, 30));

            btnEdit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnEdit.Width, btnEdit.Height, 30, 30));

            createAccount1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            createAccount1.Width, createAccount1.Height, 30, 30));

            deleteAccount1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            deleteAccount1.Width, deleteAccount1.Height, 30, 30));

            searchAccount1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            searchAccount1.Width, searchAccount1.Height, 30, 30));

            editAccount1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            editAccount1.Width, editAccount1.Height, 30, 30));


            label1.Show();
            createAccount1.Hide();
            deleteAccount1.Hide();
            searchAccount1.Hide();
            editAccount1.Hide();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                createAccount1.Hide();
                deleteAccount1.Hide();
                searchAccount1.Hide();
                editAccount1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Hide();
                createAccount1.Show();
                createAccount1.BringToFront();
                deleteAccount1.Hide();
                searchAccount1.Hide();
                editAccount1.Hide();
                formsVisible = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                createAccount1.Hide();
                deleteAccount1.Hide();
                searchAccount1.Hide();
                editAccount1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Hide();
                createAccount1.Hide();
                searchAccount1.Hide();
                editAccount1.Hide();
                deleteAccount1.Show();
                deleteAccount1.BringToFront();
                formsVisible = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                createAccount1.Hide();
                deleteAccount1.Hide();
                searchAccount1.Hide();
                editAccount1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Hide();
                createAccount1.Hide();
                editAccount1.Hide();
                deleteAccount1.Hide();
                searchAccount1.Show();
                searchAccount1.BringToFront();
                formsVisible = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (formsVisible)
            {
                label1.Show();
                createAccount1.Hide();
                deleteAccount1.Hide();
                searchAccount1.Hide();
                editAccount1.Hide();
                formsVisible = false;
            }
            else
            {
                label1.Hide();
                createAccount1.Hide();
                deleteAccount1.Hide();
                searchAccount1.Show();
                editAccount1.Show();
                editAccount1.BringToFront();
                formsVisible = true;
            }
        }

        private void editAccount1_Load(object sender, EventArgs e)
        {

        }

        private void createAccount1_Load(object sender, EventArgs e)
        {

        }

        private void CloseAccOver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
