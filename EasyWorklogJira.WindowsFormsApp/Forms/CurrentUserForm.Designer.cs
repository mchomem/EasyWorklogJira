namespace EasyWorklogJira.WindowsFormsApp.Forms
{
    partial class CurrentUserForm
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
            groupBoxUserData = new GroupBox();
            labelName = new Label();
            labelAccountId = new Label();
            labelDisplayName = new Label();
            pictureBoxUserAvatar = new PictureBox();
            groupBoxUserData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserAvatar).BeginInit();
            SuspendLayout();
            // 
            // groupBoxUserData
            // 
            groupBoxUserData.Controls.Add(labelName);
            groupBoxUserData.Controls.Add(labelAccountId);
            groupBoxUserData.Controls.Add(labelDisplayName);
            groupBoxUserData.Controls.Add(pictureBoxUserAvatar);
            groupBoxUserData.Location = new Point(12, 12);
            groupBoxUserData.Name = "groupBoxUserData";
            groupBoxUserData.Size = new Size(507, 236);
            groupBoxUserData.TabIndex = 0;
            groupBoxUserData.TabStop = false;
            groupBoxUserData.Text = "Dados";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 15.75F);
            labelName.Location = new Point(103, 68);
            labelName.Name = "labelName";
            labelName.Size = new Size(75, 30);
            labelName.TabIndex = 3;
            labelName.Text = "Nome:";
            // 
            // labelAccountId
            // 
            labelAccountId.AutoSize = true;
            labelAccountId.Location = new Point(103, 53);
            labelAccountId.Name = "labelAccountId";
            labelAccountId.Size = new Size(74, 15);
            labelAccountId.TabIndex = 2;
            labelAccountId.Text = "{Account ID}";
            // 
            // labelDisplayName
            // 
            labelDisplayName.AutoSize = true;
            labelDisplayName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelDisplayName.Location = new Point(177, 68);
            labelDisplayName.Name = "labelDisplayName";
            labelDisplayName.Size = new Size(154, 30);
            labelDisplayName.TabIndex = 1;
            labelDisplayName.Text = "{Display Name}";
            // 
            // pictureBoxUserAvatar
            // 
            pictureBoxUserAvatar.Location = new Point(17, 50);
            pictureBoxUserAvatar.Name = "pictureBoxUserAvatar";
            pictureBoxUserAvatar.Size = new Size(48, 48);
            pictureBoxUserAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxUserAvatar.TabIndex = 0;
            pictureBoxUserAvatar.TabStop = false;
            // 
            // CurrentUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 260);
            Controls.Add(groupBoxUserData);
            Name = "CurrentUserForm";
            ShowIcon = false;
            Text = "Usuário da aplicação";
            Load += CurrentUserForm_Load;
            groupBoxUserData.ResumeLayout(false);
            groupBoxUserData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxUserData;
        private PictureBox pictureBoxUserAvatar;
        private Label labelDisplayName;
        private Label labelAccountId;
        private Label labelName;
    }
}