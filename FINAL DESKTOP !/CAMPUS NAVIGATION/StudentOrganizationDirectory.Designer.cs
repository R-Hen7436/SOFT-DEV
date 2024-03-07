namespace CAMPUS_NAVIGATION
{
    partial class StudentOrganizationDirectory
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
            txtDescripton = new TextBox();
            dataGridView1 = new DataGridView();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            txtName = new TextBox();
            txtOrg = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtDescripton
            // 
            txtDescripton.BackColor = Color.FromArgb(248, 196, 0);
            txtDescripton.BorderStyle = BorderStyle.None;
            txtDescripton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            txtDescripton.ForeColor = SystemColors.InactiveCaptionText;
            txtDescripton.Location = new Point(68, 58);
            txtDescripton.Margin = new Padding(3, 2, 3, 2);
            txtDescripton.Name = "txtDescripton";
            txtDescripton.PlaceholderText = "Description";
            txtDescripton.Size = new Size(828, 32);
            txtDescripton.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(49, 99);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(859, 236);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(248, 196, 0);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.Location = new Point(962, 210);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(114, 30);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(248, 196, 0);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(962, 265);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 30);
            btnDelete.TabIndex = 7;
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
            btnAdd.Location = new Point(962, 153);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 30);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(248, 196, 0);
            txtName.BorderStyle = BorderStyle.None;
            txtName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            txtName.ForeColor = SystemColors.InactiveCaptionText;
            txtName.Location = new Point(68, 15);
            txtName.Margin = new Padding(3, 2, 3, 2);
            txtName.Name = "txtName";
            txtName.PlaceholderText = "Name";
            txtName.Size = new Size(394, 32);
            txtName.TabIndex = 2;
            // 
            // txtOrg
            // 
            txtOrg.BackColor = Color.FromArgb(248, 196, 0);
            txtOrg.BorderStyle = BorderStyle.None;
            txtOrg.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            txtOrg.ForeColor = SystemColors.InactiveCaptionText;
            txtOrg.Location = new Point(512, 15);
            txtOrg.Margin = new Padding(3, 2, 3, 2);
            txtOrg.Name = "txtOrg";
            txtOrg.PlaceholderText = "Department";
            txtOrg.Size = new Size(384, 32);
            txtOrg.TabIndex = 2;
            // 
            // StudentOrganizationDirectory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView1);
            Controls.Add(txtOrg);
            Controls.Add(txtName);
            Controls.Add(txtDescripton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "StudentOrganizationDirectory";
            Size = new Size(1140, 355);
            Load += StudentOrganizationDirectory_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDescripton;
        private DataGridView dataGridView1;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private TextBox txtName;
        private TextBox txtOrg;
    }
}
