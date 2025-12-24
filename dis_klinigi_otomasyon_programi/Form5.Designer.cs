namespace dis_klinigi_otomasyon_programi
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton4 = new RadioButton();
            pictureBox1 = new PictureBox();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 100);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSeaGreen;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(radioButton4);
            panel1.Controls.Add(radioButton3);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 100);
            panel1.TabIndex = 1;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.BackColor = Color.White;
            radioButton1.Font = new Font("Franklin Gothic Medium", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton1.ForeColor = Color.LightSeaGreen;
            radioButton1.Location = new Point(330, 36);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(99, 28);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "randevu";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.BackColor = Color.White;
            radioButton2.Font = new Font("Franklin Gothic Medium", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton2.ForeColor = Color.LightSeaGreen;
            radioButton2.Location = new Point(484, 36);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(109, 28);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "reçeteler";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.BackColor = Color.White;
            radioButton3.Font = new Font("Franklin Gothic Medium", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton3.ForeColor = Color.LightSeaGreen;
            radioButton3.Location = new Point(630, 36);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(83, 28);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "tedavi";
            radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.BackColor = Color.White;
            radioButton4.Font = new Font("Franklin Gothic Medium", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            radioButton4.ForeColor = Color.LightSeaGreen;
            radioButton4.Location = new Point(206, 36);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(78, 28);
            radioButton4.TabIndex = 3;
            radioButton4.TabStop = true;
            radioButton4.Text = "hasta";
            radioButton4.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(37, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(107, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(220, 113);
            label4.Name = "label4";
            label4.Size = new Size(348, 47);
            label4.TabIndex = 5;
            label4.Text = "istanbul dental klinik";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(254, 254);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 50);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox2);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Name = "Form5";
            Text = "Form5";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private PictureBox pictureBox1;
        private Label label4;
        private PictureBox pictureBox2;
    }
}