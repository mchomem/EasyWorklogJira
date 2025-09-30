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
            SuspendLayout();
            // 
            // labelTextAbout
            // 
            labelTextAbout.AutoSize = true;
            labelTextAbout.Location = new Point(12, 91);
            labelTextAbout.Name = "labelTextAbout";
            labelTextAbout.Size = new Size(16, 15);
            labelTextAbout.TabIndex = 0;
            labelTextAbout.Text = "...";
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(labelTextAbout);
            Name = "AboutForm";
            Text = "Sobre";
            Load += AboutForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTextAbout;
    }
}