using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAMPUS_NAVIGATION
{
    public partial class CampusTours : UserControl
    {
        public CampusTours()
        {
            InitializeComponent();
        }

        private void CampusTours_Load(object sender, EventArgs e)
        {
            // Assuming richTextBox1 is the name of your RichTextBox control
            richTextBox1.Text = "https://youtu.be/tIwudijrMEw?si=FxuDUJKLjuwTz3il";

            // Hook up the event handler for the LinkClicked event
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;

        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                // Start the default web browser with the URL
                Process.Start(new ProcessStartInfo
                {
                    FileName = e.LinkText,
                    UseShellExecute = true
                });
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show($"Error opening link: {ex.Message}");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}
