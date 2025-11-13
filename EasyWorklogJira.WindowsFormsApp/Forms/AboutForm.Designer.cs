namespace EasyWorklogJira.WindowsFormsApp.Forms
{
    partial class AboutForm
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
            labelTextAbout = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelTextAbout
            // 
            labelTextAbout.AutoSize = true;
            labelTextAbout.Location = new Point(12, 95);
            labelTextAbout.Name = "labelTextAbout";
            labelTextAbout.Size = new Size(16, 15);
            labelTextAbout.TabIndex = 0;
            labelTextAbout.Text = "...";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resource.ewj_banner;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(460, 80);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(pictureBox1);
            Controls.Add(labelTextAbout);
            Name = "AboutForm";
            ShowIcon = false;
            Text = "Sobre";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTextAbout;
        private PictureBox pictureBox1;
    }
}