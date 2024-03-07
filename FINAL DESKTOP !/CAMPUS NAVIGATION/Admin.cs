using System.Runtime.InteropServices;

namespace CAMPUS_NAVIGATION
{
    public partial class Admin : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nleft, int nTop,
        int nRight, int nBottom,
        int nWidthEllipse,
        int nHeightEllipse);

        private AccountOverview accountOverview = null;
        private UpdatesFF updatesFF = null;
        private Feedbacks feedbacks = null;
        private Notifications notifications = null;
        private Form1 form1 = null;

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            btnAccOverview.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnAccOverview.Width, btnAccOverview.Height, 30, 30));

            btnFeedback.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnFeedback.Width, btnFeedback.Height, 30, 30));

            btnLogout.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnLogout.Width, btnLogout.Height, 30, 30));

            btnUpdatesff.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnUpdatesff.Width, btnUpdatesff.Height, 30, 30));

            btnNotif.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0,
            btnNotif.Width, btnNotif.Height, 30, 30));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AccountOverview accountOverview = new AccountOverview();
            //accountOverview.Show();
            accountOverview = new AccountOverview();

            if (accountOverview == null || accountOverview.IsDisposed)
            {

                accountOverview.ShowDialog();
            }
            else
            {
                accountOverview.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //UpdatesFF updatesFF = new UpdatesFF();
            //updatesFF.Show();
            updatesFF = new UpdatesFF();
            if (updatesFF == null || updatesFF.IsDisposed)
            {
                updatesFF.ShowDialog();
            }
            else
            {
                updatesFF.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            notifications = new Notifications();
            if (notifications == null || notifications.IsDisposed)
            {
                notifications.ShowDialog();
            }
            else
            {
                notifications.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Feedbacks feedback = new Feedbacks();
            //feedback.Show();
            feedbacks = new Feedbacks();
            if (feedbacks == null || feedbacks.IsDisposed)
            {
                feedbacks.ShowDialog();
            }
            else
            {
                feedbacks.ShowDialog();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //Form1 form = new Form1();
            //form.Show();
            this.Close();

            if (form1 == null || form1.IsDisposed)
            {
                form1 = new Form1();
                form1.Show();
            }
            else
            {
                form1.Close();
                form1 = null;

            }
            
        }
    }
}
