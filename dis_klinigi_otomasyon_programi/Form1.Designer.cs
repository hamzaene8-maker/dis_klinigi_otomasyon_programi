namespace dis_klinigi_otomasyon_programi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            radioButton1 = new RadioButton();
            label1 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkTurquoise;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 100);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(56, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(107, 94);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(219, 210);
            label2.Name = "label2";
            label2.Size = new Size(129, 21);
            label2.TabIndex = 1;
            label2.Text = "KULLANICI ADI:";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox1.Location = new Point(354, 210);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Franklin Gothic Medium", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(288, 261);
            label3.Name = "label3";
            label3.Size = new Size(60, 21);
            label3.TabIndex = 3;
            label3.Text = "ŞİFRE:";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.White;
            textBox2.ForeColor = Color.MediumTurquoise;
            textBox2.Location = new Point(354, 262);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.DarkTurquoise;
            radioButton1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton1.ForeColor = Color.White;
            radioButton1.Location = new Point(330, 331);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(77, 23);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "LOGIN";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(253, 23);
            label1.Name = "label1";
            label1.Size = new Size(381, 47);
            label1.TabIndex = 2;
            label1.Text = "diş kliniği otomasyonu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(219, 117);
            label4.Name = "label4";
            label4.Size = new Size(348, 47);
            label4.TabIndex = 3;
            label4.Text = "istanbul dental klinik";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(radioButton1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(panel1);
            ForeColor = Color.Cyan;
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private RadioButton radioButton1;
        private Label label1;
        private Label label4;
    }
}
