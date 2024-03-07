namespace CAMPUS_NAVIGATION
{
    partial class Notifications
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            radStaff = new RadioButton();
            btnUpdate = new Button();
            btnAddNotif = new Button();
            dataGridView1 = new DataGridView();
            radSecurity = new RadioButton();
            radStudent = new RadioButton();
            radProfessor = new RadioButton();
            radAll = new RadioButton();
            richTextBox1 = new RichTextBox();
            CloseNotif = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Maroon;
            panel1.Controls.Add(CloseNotif);
            panel1.Controls.Add(radStaff);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnAddNotif);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(radSecurity);
            panel1.Controls.Add(radStudent);
            panel1.Controls.Add(radProfessor);
            panel1.Controls.Add(radAll);
            panel1.Controls.Add(richTextBox1);
            panel1.Location = new Point(35, 20);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1261, 484);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // radStaff
            // 
            radStaff.AutoSize = true;
            radStaff.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radStaff.ForeColor = SystemColors.ButtonHighlight;
            radStaff.Location = new Point(113, 97);
            radStaff.Name = "radStaff";
            radStaff.Size = new Size(63, 25);
            radStaff.TabIndex = 7;
            radStaff.TabStop = true;
            radStaff.Text = "Staff";
            radStaff.UseVisualStyleBackColor = true;
            radStaff.CheckedChanged += radStaff_CheckedChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(248, 196, 0);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.Location = new Point(831, 404);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(147, 27);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAddNotif
            // 
            btnAddNotif.BackColor = Color.FromArgb(248, 196, 0);
            btnAddNotif.FlatAppearance.BorderSize = 0;
            btnAddNotif.FlatStyle = FlatStyle.Flat;
            btnAddNotif.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddNotif.Location = new Point(73, 376);
            btnAddNotif.Margin = new Padding(3, 2, 3, 2);
            btnAddNotif.Name = "btnAddNotif";
            btnAddNotif.Size = new Size(187, 32);
            btnAddNotif.TabIndex = 6;
            btnAddNotif.Text = "Send Notification";
            btnAddNotif.UseVisualStyleBackColor = false;
            btnAddNotif.Click += btnAddNotif_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(602, 40);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(575, 338);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // radSecurity
            // 
            radSecurity.AutoSize = true;
            radSecurity.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radSecurity.ForeColor = SystemColors.ButtonHighlight;
            radSecurity.Location = new Point(339, 68);
            radSecurity.Margin = new Padding(3, 2, 3, 2);
            radSecurity.Name = "radSecurity";
            radSecurity.Size = new Size(142, 25);
            radSecurity.TabIndex = 1;
            radSecurity.TabStop = true;
            radSecurity.Text = "Security Guards";
            radSecurity.UseVisualStyleBackColor = true;
            radSecurity.CheckedChanged += radSecurity_CheckedChanged;
            // 
            // radStudent
            // 
            radStudent.AutoSize = true;
            radStudent.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radStudent.ForeColor = SystemColors.ButtonHighlight;
            radStudent.Location = new Point(339, 28);
            radStudent.Margin = new Padding(3, 2, 3, 2);
            radStudent.Name = "radStudent";
            radStudent.Size = new Size(93, 25);
            radStudent.TabIndex = 1;
            radStudent.TabStop = true;
            radStudent.Text = "Students";
            radStudent.UseVisualStyleBackColor = true;
            radStudent.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // radProfessor
            // 
            radProfessor.AutoSize = true;
            radProfessor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radProfessor.ForeColor = SystemColors.ButtonHighlight;
            radProfessor.Location = new Point(113, 67);
            radProfessor.Margin = new Padding(3, 2, 3, 2);
            radProfessor.Name = "radProfessor";
            radProfessor.Size = new Size(105, 25);
            radProfessor.TabIndex = 1;
            radProfessor.TabStop = true;
            radProfessor.Text = "Professors";
            radProfessor.UseVisualStyleBackColor = true;
            radProfessor.CheckedChanged += radProfessor_CheckedChanged;
            // 
            // radAll
            // 
            radAll.AutoSize = true;
            radAll.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radAll.ForeColor = SystemColors.ButtonHighlight;
            radAll.Location = new Point(113, 28);
            radAll.Margin = new Padding(3, 2, 3, 2);
            radAll.Name = "radAll";
            radAll.Size = new Size(47, 25);
            radAll.TabIndex = 1;
            radAll.TabStop = true;
            radAll.Text = "All";
            radAll.UseVisualStyleBackColor = true;
            radAll.CheckedChanged += radAll_CheckedChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(73, 121);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(467, 224);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // CloseNotif
            // 
            CloseNotif.Anchor = AnchorStyles.None;
            CloseNotif.BackColor = Color.FromArgb(248, 196, 0);
            CloseNotif.FlatAppearance.BorderSize = 0;
            CloseNotif.FlatStyle = FlatStyle.Flat;
            CloseNotif.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CloseNotif.ForeColor = SystemColors.ActiveCaptionText;
            CloseNotif.Location = new Point(1224, 11);
            CloseNotif.Margin = new Padding(3, 2, 3, 2);
            CloseNotif.Name = "CloseNotif";
            CloseNotif.Size = new Size(25, 27);
            CloseNotif.TabIndex = 8;
            CloseNotif.Text = "X";
            CloseNotif.UseVisualStyleBackColor = false;
            CloseNotif.Click += CloseNotif_Click;
            // 
            // Notifications
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 196, 0);
            ClientSize = new Size(1330, 525);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(200, 300);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Notifications";
            StartPosition = FormStartPosition.Manual;
            Text = "ALL";
            Load += Notifications_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private RadioButton radAll;
        private RichTextBox richTextBox1;
        private Button btnAddNotif;
        private DataGridView dataGridView1;
        private RadioButton radSecurity;
        private RadioButton radStudent;
        private RadioButton radProfessor;
        private Button btnUpdate;
        private RadioButton radStaff;
        private Button CloseNotif;
    }
}