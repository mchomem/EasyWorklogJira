namespace EasyWorklogJira.WindowsFormsApp.Forms
{
    partial class ConfigurationForm
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
            labelEmail = new Label();
            textBoxEmail = new TextBox();
            labelToken = new Label();
            textBoxToken = new TextBox();
            buttonSave = new Button();
            labelInformationToken = new Label();
            linkLabel = new LinkLabel();
            buttonClose = new Button();
            groupBoxJiraAccessCredentials = new GroupBox();
            groupBoxDailyMeetingSchedule = new GroupBox();
            maskedTextBoxEndTime = new MaskedTextBox();
            labelEndTime = new Label();
            maskedTextBoxStartTime = new MaskedTextBox();
            labelStartTime = new Label();
            groupBoxWebSite = new GroupBox();
            textBoxUrlBase = new TextBox();
            labelUrlBase = new Label();
            labelWarningRule = new Label();
            groupBoxJiraAccessCredentials.SuspendLayout();
            groupBoxDailyMeetingSchedule.SuspendLayout();
            groupBoxWebSite.SuspendLayout();
            SuspendLayout();
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(26, 31);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(44, 15);
            labelEmail.TabIndex = 4;
            labelEmail.Text = "e-mail:";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(84, 26);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(353, 23);
            textBoxEmail.TabIndex = 5;
            // 
            // labelToken
            // 
            labelToken.AutoSize = true;
            labelToken.Location = new Point(26, 98);
            labelToken.Name = "labelToken";
            labelToken.Size = new Size(42, 15);
            labelToken.TabIndex = 8;
            labelToken.Text = "Token:";
            // 
            // textBoxToken
            // 
            textBoxToken.Location = new Point(84, 95);
            textBoxToken.Name = "textBoxToken";
            textBoxToken.Size = new Size(353, 23);
            textBoxToken.TabIndex = 9;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(399, 325);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 16;
            buttonSave.Text = "Salvar";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelInformationToken
            // 
            labelInformationToken.AutoSize = true;
            labelInformationToken.Location = new Point(26, 63);
            labelInformationToken.Name = "labelInformationToken";
            labelInformationToken.Size = new Size(111, 15);
            labelInformationToken.TabIndex = 6;
            labelInformationToken.Text = "Gere seu token em: ";
            // 
            // linkLabel
            // 
            linkLabel.AutoSize = true;
            linkLabel.Location = new Point(151, 63);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new Size(286, 15);
            linkLabel.TabIndex = 7;
            linkLabel.TabStop = true;
            linkLabel.Text = "id.atlassian.com/manage-profile/security/api-tokens";
            linkLabel.LinkClicked += linkLabel_LinkClicked;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(318, 325);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 15;
            buttonClose.Text = "Fechar";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // groupBoxJiraAccessCredentials
            // 
            groupBoxJiraAccessCredentials.Controls.Add(textBoxToken);
            groupBoxJiraAccessCredentials.Controls.Add(labelEmail);
            groupBoxJiraAccessCredentials.Controls.Add(linkLabel);
            groupBoxJiraAccessCredentials.Controls.Add(textBoxEmail);
            groupBoxJiraAccessCredentials.Controls.Add(labelInformationToken);
            groupBoxJiraAccessCredentials.Controls.Add(labelToken);
            groupBoxJiraAccessCredentials.Location = new Point(12, 103);
            groupBoxJiraAccessCredentials.Name = "groupBoxJiraAccessCredentials";
            groupBoxJiraAccessCredentials.Size = new Size(462, 140);
            groupBoxJiraAccessCredentials.TabIndex = 3;
            groupBoxJiraAccessCredentials.TabStop = false;
            groupBoxJiraAccessCredentials.Text = "Credenciais de Acesso do Jira";
            // 
            // groupBoxDailyMeetingSchedule
            // 
            groupBoxDailyMeetingSchedule.Controls.Add(maskedTextBoxEndTime);
            groupBoxDailyMeetingSchedule.Controls.Add(labelEndTime);
            groupBoxDailyMeetingSchedule.Controls.Add(maskedTextBoxStartTime);
            groupBoxDailyMeetingSchedule.Controls.Add(labelStartTime);
            groupBoxDailyMeetingSchedule.Location = new Point(12, 249);
            groupBoxDailyMeetingSchedule.Name = "groupBoxDailyMeetingSchedule";
            groupBoxDailyMeetingSchedule.Size = new Size(462, 70);
            groupBoxDailyMeetingSchedule.TabIndex = 10;
            groupBoxDailyMeetingSchedule.TabStop = false;
            groupBoxDailyMeetingSchedule.Text = "Horário da Daily *";
            // 
            // maskedTextBoxEndTime
            // 
            maskedTextBoxEndTime.Location = new Point(281, 24);
            maskedTextBoxEndTime.Mask = "00:00";
            maskedTextBoxEndTime.Name = "maskedTextBoxEndTime";
            maskedTextBoxEndTime.Size = new Size(34, 23);
            maskedTextBoxEndTime.TabIndex = 14;
            // 
            // labelEndTime
            // 
            labelEndTime.AutoSize = true;
            labelEndTime.Location = new Point(172, 28);
            labelEndTime.Name = "labelEndTime";
            labelEndTime.Size = new Size(100, 15);
            labelEndTime.TabIndex = 13;
            labelEndTime.Text = "Hora do Término:";
            // 
            // maskedTextBoxStartTime
            // 
            maskedTextBoxStartTime.Location = new Point(116, 25);
            maskedTextBoxStartTime.Mask = "00:00";
            maskedTextBoxStartTime.Name = "maskedTextBoxStartTime";
            maskedTextBoxStartTime.Size = new Size(33, 23);
            maskedTextBoxStartTime.TabIndex = 12;
            // 
            // labelStartTime
            // 
            labelStartTime.AutoSize = true;
            labelStartTime.Location = new Point(26, 28);
            labelStartTime.Name = "labelStartTime";
            labelStartTime.Size = new Size(84, 15);
            labelStartTime.TabIndex = 11;
            labelStartTime.Text = "Hora de Início:";
            // 
            // groupBoxWebSite
            // 
            groupBoxWebSite.Controls.Add(textBoxUrlBase);
            groupBoxWebSite.Controls.Add(labelUrlBase);
            groupBoxWebSite.Location = new Point(12, 12);
            groupBoxWebSite.Name = "groupBoxWebSite";
            groupBoxWebSite.Size = new Size(465, 73);
            groupBoxWebSite.TabIndex = 0;
            groupBoxWebSite.TabStop = false;
            groupBoxWebSite.Text = "Web Site";
            // 
            // textBoxUrlBase
            // 
            textBoxUrlBase.Location = new Point(84, 31);
            textBoxUrlBase.Name = "textBoxUrlBase";
            textBoxUrlBase.Size = new Size(353, 23);
            textBoxUrlBase.TabIndex = 2;
            // 
            // labelUrlBase
            // 
            labelUrlBase.AutoSize = true;
            labelUrlBase.Location = new Point(26, 36);
            labelUrlBase.Name = "labelUrlBase";
            labelUrlBase.Size = new Size(52, 15);
            labelUrlBase.TabIndex = 1;
            labelUrlBase.Text = "Url Base:";
            // 
            // labelWarningRule
            // 
            labelWarningRule.AutoSize = true;
            labelWarningRule.Location = new Point(12, 368);
            labelWarningRule.Name = "labelWarningRule";
            labelWarningRule.Size = new Size(86, 15);
            labelWarningRule.TabIndex = 17;
            labelWarningRule.Text = "{Warning Rule}";
            // 
            // ConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 395);
            Controls.Add(labelWarningRule);
            Controls.Add(groupBoxWebSite);
            Controls.Add(groupBoxDailyMeetingSchedule);
            Controls.Add(groupBoxJiraAccessCredentials);
            Controls.Add(buttonClose);
            Controls.Add(buttonSave);
            Name = "ConfigurationForm";
            Text = "Configuração";
            groupBoxJiraAccessCredentials.ResumeLayout(false);
            groupBoxJiraAccessCredentials.PerformLayout();
            groupBoxDailyMeetingSchedule.ResumeLayout(false);
            groupBoxDailyMeetingSchedule.PerformLayout();
            groupBoxWebSite.ResumeLayout(false);
            groupBoxWebSite.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelEmail;
        private TextBox textBoxEmail;
        private Label labelToken;
        private TextBox textBoxToken;
        private Button buttonSave;
        private Label labelInformationToken;
        private LinkLabel linkLabel;
        private Button buttonClose;
        private GroupBox groupBoxJiraAccessCredentials;
        private GroupBox groupBoxDailyMeetingSchedule;
        private MaskedTextBox maskedTextBoxStartTime;
        private Label labelStartTime;
        private Label labelEndTime;
        private MaskedTextBox maskedTextBoxEndTime;
        private GroupBox groupBoxWebSite;
        private TextBox textBoxUrlBase;
        private Label labelUrlBase;
        private Label labelWarningRule;
    }
}