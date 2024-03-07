namespace CAMPUS_NAVIGATION
{
    partial class CampusServicesDirectory
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
            txtService = new TextBox();
            dataGridView1 = new DataGridView();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            txtEmail = new TextBox();
            txtContactNum = new TextBox();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtService
            // 
            txtService.BackColor = Color.FromArgb(248, 196, 0);
            txtService.BorderStyle = BorderStyle.None;
            txtService.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            txtService.ForeColor = SystemColors.InactiveCaptionText;
            txtService.Location = new Point(66, 7);
            txtService.Margin = new Padding(3, 2, 3, 2);
            txtService.Name = "txtService";
            txtService.PlaceholderText = "Campus Service";
            txtService.Size = new Size(484, 32);
            txtService.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 82);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1046, 229);
            dataGridView1.TabIndex = 2;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(248, 196, 0);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.Location = new Point(712, 315);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(114, 30);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Refresh";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(248, 196, 0);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(513, 315);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 30);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(248, 196, 0);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(316, 315);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 30);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(248, 196, 0);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            txtEmail.ForeColor = SystemColors.InactiveCaptionText;
            txtEmail.Location = new Point(326, 47);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(484, 32);
            txtEmail.TabIndex = 6;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // txtContactNum
            // 
            txtContactNum.BackColor = Color.FromArgb(248, 196, 0);
            txtContactNum.BorderStyle = BorderStyle.None;
            txtContactNum.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            txtContactNum.ForeColor = SystemColors.InactiveCaptionText;
            txtContactNum.Location = new Point(589, 7);
            txtContactNum.Margin = new Padding(3, 2, 3, 2);
            txtContactNum.Name = "txtContactNum";
            txtContactNum.PlaceholderText = "Contact Number";
            txtContactNum.Size = new Size(484, 32);
            txtContactNum.TabIndex = 6;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(248, 196, 0);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.Location = new Point(858, 315);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(114, 30);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // CampusServicesDirectory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            Controls.Add(btnEdit);
            Controls.Add(txtContactNum);
            Controls.Add(txtEmail);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Controls.Add(txtService);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CampusServicesDirectory";
            Size = new Size(1140, 353);
            Load += CampusServicesDirectory_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtService;
        private DataGridView dataGridView1;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private TextBox txtEmail;
        private TextBox txtContactNum;
        private Button btnEdit;
    }
}
