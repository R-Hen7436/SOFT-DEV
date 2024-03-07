namespace CAMPUS_NAVIGATION
{
    partial class EventCalendar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtIDImage = new TextBox();
            btnBrowse = new Button();
            btnInsert = new Button();
            btnRetrieve = new Button();
            panel1 = new Panel();
            pctCalender = new PictureBox();
            txtNAMEImage = new TextBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctCalender).BeginInit();
            SuspendLayout();
            // 
            // txtIDImage
            // 
            txtIDImage.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtIDImage.Location = new Point(615, 52);
            txtIDImage.Margin = new Padding(3, 2, 3, 2);
            txtIDImage.Name = "txtIDImage";
            txtIDImage.PlaceholderText = "IMAGE_ID";
            txtIDImage.Size = new Size(475, 32);
            txtIDImage.TabIndex = 1;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(248, 196, 0);
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnBrowse.Location = new Point(655, 168);
            btnBrowse.Margin = new Padding(3, 2, 3, 2);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(139, 26);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnInsert
            // 
            btnInsert.BackColor = Color.FromArgb(248, 196, 0);
            btnInsert.FlatAppearance.BorderSize = 0;
            btnInsert.FlatStyle = FlatStyle.Flat;
            btnInsert.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnInsert.Location = new Point(655, 217);
            btnInsert.Margin = new Padding(3, 2, 3, 2);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(139, 26);
            btnInsert.TabIndex = 2;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = false;
            btnInsert.Click += btnSearch_Click;
            // 
            // btnRetrieve
            // 
            btnRetrieve.BackColor = Color.FromArgb(248, 196, 0);
            btnRetrieve.FlatAppearance.BorderSize = 0;
            btnRetrieve.FlatStyle = FlatStyle.Flat;
            btnRetrieve.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnRetrieve.Location = new Point(908, 168);
            btnRetrieve.Margin = new Padding(3, 2, 3, 2);
            btnRetrieve.Name = "btnRetrieve";
            btnRetrieve.Size = new Size(139, 26);
            btnRetrieve.TabIndex = 2;
            btnRetrieve.Text = "Retrieve";
            btnRetrieve.UseVisualStyleBackColor = false;
            btnRetrieve.Click += btnRetrieve_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(248, 196, 0);
            panel1.Controls.Add(pctCalender);
            panel1.Location = new Point(79, 14);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(464, 326);
            panel1.TabIndex = 3;
            // 
            // pctCalender
            // 
            pctCalender.BackColor = Color.White;
            pctCalender.Location = new Point(43, 17);
            pctCalender.Margin = new Padding(3, 2, 3, 2);
            pctCalender.Name = "pctCalender";
            pctCalender.Size = new Size(378, 294);
            pctCalender.TabIndex = 0;
            pctCalender.TabStop = false;
            // 
            // txtNAMEImage
            // 
            txtNAMEImage.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            txtNAMEImage.Location = new Point(615, 98);
            txtNAMEImage.Margin = new Padding(3, 2, 3, 2);
            txtNAMEImage.Name = "txtNAMEImage";
            txtNAMEImage.PlaceholderText = "IMAGE_NAME";
            txtNAMEImage.Size = new Size(475, 32);
            txtNAMEImage.TabIndex = 4;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(248, 196, 0);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(908, 220);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(139, 26);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(248, 196, 0);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.Location = new Point(780, 272);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(139, 26);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // EventCalendar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(txtNAMEImage);
            Controls.Add(panel1);
            Controls.Add(btnRetrieve);
            Controls.Add(btnInsert);
            Controls.Add(btnBrowse);
            Controls.Add(txtIDImage);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EventCalendar";
            Size = new Size(1140, 355);
            Load += EventCalendar_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pctCalender).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtIDImage;
        private Button btnBrowse;
        private Button btnInsert;
        private Button btnRetrieve;
        private Panel panel1;
        private PictureBox pctCalender;
        private TextBox txtNAMEImage;
        private Button btnDelete;
        private Button btnUpdate;
    }
}
