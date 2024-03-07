namespace CAMPUS_NAVIGATION
{
    partial class EmergencyContacts
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
            panel1 = new Panel();
            txtName = new TextBox();
            txtNumber = new TextBox();
            txtLocation = new TextBox();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            btnEdit = new Button();
            textBox1 = new TextBox();
            btnSearch = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(248, 196, 0);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(txtNumber);
            panel1.Controls.Add(txtLocation);
            panel1.Location = new Point(34, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(470, 259);
            panel1.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtName.Location = new Point(22, 44);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(415, 31);
            txtName.TabIndex = 0;
            // 
            // txtNumber
            // 
            txtNumber.BorderStyle = BorderStyle.None;
            txtNumber.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtNumber.Location = new Point(22, 111);
            txtNumber.Name = "txtNumber";
            txtNumber.PlaceholderText = "Mobile/Telephone Number";
            txtNumber.Size = new Size(415, 31);
            txtNumber.TabIndex = 0;
            // 
            // txtLocation
            // 
            txtLocation.BorderStyle = BorderStyle.None;
            txtLocation.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            txtLocation.Location = new Point(22, 173);
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "Location";
            txtLocation.Size = new Size(415, 31);
            txtLocation.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(567, 21);
            panel2.Name = "panel2";
            panel2.Size = new Size(706, 371);
            panel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(706, 371);
            dataGridView1.TabIndex = 0;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(248, 196, 0);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.Location = new Point(1050, 408);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(113, 39);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Update";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(567, 411);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(329, 34);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(248, 196, 0);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.Location = new Point(940, 408);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(98, 39);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(248, 196, 0);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(207, 357);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(127, 35);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(248, 196, 0);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(1175, 408);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(98, 39);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // EmergencyContacts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            Controls.Add(textBox1);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnSearch);
            Controls.Add(btnEdit);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "EmergencyContacts";
            Size = new Size(1303, 473);
            Load += EmergencyContacts_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button btnEdit;
        private TextBox textBox1;
        private Button btnSearch;
        private Button btnAdd;
        private Button btnDelete;
        private TextBox txtName;
        private TextBox txtNumber;
        private TextBox txtLocation;
    }
}
