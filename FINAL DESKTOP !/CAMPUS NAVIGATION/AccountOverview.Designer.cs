namespace CAMPUS_NAVIGATION
{
    partial class AccountOverview
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
            btnCreate = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            btnEdit = new Button();
            panel1 = new Panel();
            editAccount1 = new EditAccount();
            searchAccount1 = new SearchAccount();
            deleteAccount1 = new DeleteAccount();
            createAccount1 = new CreateAccount();
            label1 = new Label();
            CloseAccOver = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Maroon;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnCreate.ForeColor = SystemColors.ButtonHighlight;
            btnCreate.Location = new Point(148, 23);
            btnCreate.Margin = new Padding(3, 2, 3, 2);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(201, 30);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Create Account";
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Maroon;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.ButtonHighlight;
            btnDelete.Location = new Point(435, 23);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(191, 30);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete Account";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Maroon;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearch.ForeColor = SystemColors.ButtonHighlight;
            btnSearch.Location = new Point(739, 23);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(205, 30);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search Account";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Maroon;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.ButtonHighlight;
            btnEdit.Location = new Point(1025, 23);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(191, 30);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit Account";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(editAccount1);
            panel1.Controls.Add(searchAccount1);
            panel1.Controls.Add(deleteAccount1);
            panel1.Controls.Add(createAccount1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(96, 91);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1134, 396);
            panel1.TabIndex = 2;
            // 
            // editAccount1
            // 
            editAccount1.Location = new Point(3, 0);
            editAccount1.Margin = new Padding(3, 2, 3, 2);
            editAccount1.Name = "editAccount1";
            editAccount1.Size = new Size(1418, 495);
            editAccount1.TabIndex = 7;
            // 
            // searchAccount1
            // 
            searchAccount1.Location = new Point(3, 2);
            searchAccount1.Margin = new Padding(3, 2, 3, 2);
            searchAccount1.Name = "searchAccount1";
            searchAccount1.Size = new Size(1418, 495);
            searchAccount1.TabIndex = 6;
            // 
            // deleteAccount1
            // 
            deleteAccount1.Location = new Point(3, 0);
            deleteAccount1.Margin = new Padding(3, 2, 3, 2);
            deleteAccount1.Name = "deleteAccount1";
            deleteAccount1.Size = new Size(1418, 495);
            deleteAccount1.TabIndex = 5;
            // 
            // createAccount1
            // 
            createAccount1.BackColor = Color.FromArgb(248, 196, 0);
            createAccount1.Location = new Point(3, 0);
            createAccount1.Margin = new Padding(3, 2, 3, 2);
            createAccount1.Name = "createAccount1";
            createAccount1.Size = new Size(1418, 495);
            createAccount1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Baskerville Old Face", 19.8000011F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(234, 173);
            label1.Name = "label1";
            label1.Size = new Size(588, 31);
            label1.TabIndex = 3;
            label1.Text = "\"Your Ultimate Cebu Institute Tech Companion\"";
            // 
            // CloseAccOver
            // 
            CloseAccOver.BackColor = Color.Maroon;
            CloseAccOver.FlatAppearance.BorderSize = 0;
            CloseAccOver.FlatStyle = FlatStyle.Flat;
            CloseAccOver.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            CloseAccOver.ForeColor = SystemColors.ButtonHighlight;
            CloseAccOver.Location = new Point(1282, 11);
            CloseAccOver.Margin = new Padding(3, 2, 3, 2);
            CloseAccOver.Name = "CloseAccOver";
            CloseAccOver.Size = new Size(36, 32);
            CloseAccOver.TabIndex = 3;
            CloseAccOver.Text = "X";
            CloseAccOver.UseVisualStyleBackColor = false;
            CloseAccOver.Click += CloseAccOver_Click;
            // 
            // AccountOverview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 196, 0);
            ClientSize = new Size(1330, 525);
            Controls.Add(CloseAccOver);
            Controls.Add(panel1);
            Controls.Add(btnEdit);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnCreate);
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(200, 300);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AccountOverview";
            StartPosition = FormStartPosition.Manual;
            Text = "AccountOverview";
            Load += AccountOverview_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnCreate;
        private Button btnDelete;
        private Button btnSearch;
        private Button btnEdit;
        private Panel panel1;
        private Label label1;
        private DeleteAccount deleteAccount1;
        private CreateAccount createAccount1;
        private EditAccount editAccount1;
        private SearchAccount searchAccount1;
        private Button CloseAccOver;
    }
}