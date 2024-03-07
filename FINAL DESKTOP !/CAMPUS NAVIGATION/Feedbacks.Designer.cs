namespace CAMPUS_NAVIGATION
{
    partial class Feedbacks
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
            btnDelete = new Button();
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            CloseFeedBack = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Maroon;
            panel1.Controls.Add(CloseFeedBack);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(10, 9);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1309, 507);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(248, 196, 0);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.Location = new Point(496, 359);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(105, 26);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(46, 144);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(555, 190);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(46, 97);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "ID Number";
            textBox1.Size = new Size(383, 32);
            textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(682, 34);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(573, 388);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // CloseFeedBack
            // 
            CloseFeedBack.Anchor = AnchorStyles.None;
            CloseFeedBack.BackColor = Color.FromArgb(248, 196, 0);
            CloseFeedBack.FlatAppearance.BorderSize = 0;
            CloseFeedBack.FlatStyle = FlatStyle.Flat;
            CloseFeedBack.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CloseFeedBack.ForeColor = SystemColors.ActiveCaptionText;
            CloseFeedBack.Location = new Point(1271, 14);
            CloseFeedBack.Margin = new Padding(3, 2, 3, 2);
            CloseFeedBack.Name = "CloseFeedBack";
            CloseFeedBack.Size = new Size(25, 27);
            CloseFeedBack.TabIndex = 4;
            CloseFeedBack.Text = "X";
            CloseFeedBack.UseVisualStyleBackColor = false;
            CloseFeedBack.Click += CloseFeedBack_Click;
            // 
            // Feedbacks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 196, 0);
            ClientSize = new Size(1330, 525);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(200, 300);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Feedbacks";
            StartPosition = FormStartPosition.Manual;
            Text = "Feedbacks";
            Load += Feedbacks_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button btnDelete;
        private RichTextBox richTextBox1;
        private Button CloseFeedBack;
    }
}