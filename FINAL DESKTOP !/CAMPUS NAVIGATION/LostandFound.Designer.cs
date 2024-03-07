namespace CAMPUS_NAVIGATION
{
    partial class LostandFound
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
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            btnUpdate = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            btnEdit = new Button();
            btnDelete = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox5 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(3, 33);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Name: Who found it?";
            textBox1.Size = new Size(386, 38);
            textBox1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 165);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(923, 259);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(248, 196, 0);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = SystemColors.ControlText;
            btnUpdate.Location = new Point(1074, 203);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(147, 40);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = " Add";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(3, 99);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Item:What object is lost/found?";
            textBox2.Size = new Size(386, 38);
            textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(407, 33);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Place: Where is it found?";
            textBox3.Size = new Size(375, 38);
            textBox3.TabIndex = 0;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(407, 99);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Others: Other information";
            textBox4.Size = new Size(375, 38);
            textBox4.TabIndex = 0;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(248, 196, 0);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnEdit.ForeColor = SystemColors.ControlText;
            btnEdit.Location = new Point(1074, 275);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(147, 40);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Update";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(248, 196, 0);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = SystemColors.ControlText;
            btnDelete.Location = new Point(1074, 349);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(147, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(248, 196, 0);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(1019, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 125);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Maroon;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(245, 119);
            panel2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(109, 31);
            label3.Name = "label3";
            label3.Size = new Size(40, 23);
            label3.TabIndex = 0;
            label3.Text = "and";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(120, 59);
            label2.Name = "label2";
            label2.Size = new Size(116, 38);
            label2.TabIndex = 0;
            label2.Text = "FOUND";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(21, 16);
            label1.Name = "label1";
            label1.Size = new Size(83, 38);
            label1.TabIndex = 0;
            label1.Text = "LOST";
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox5.Location = new Point(790, 33);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Claim Here @";
            textBox5.Size = new Size(222, 38);
            textBox5.TabIndex = 4;
            // 
            // LostandFound
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Maroon;
            Controls.Add(textBox5);
            Controls.Add(panel1);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnUpdate);
            Controls.Add(dataGridView1);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Name = "LostandFound";
            Size = new Size(1303, 473);
            Load += LostandFound_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button btnUpdate;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button btnEdit;
        private Button btnDelete;
        private Panel panel1;
        private Panel panel2;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox5;
    }
}
