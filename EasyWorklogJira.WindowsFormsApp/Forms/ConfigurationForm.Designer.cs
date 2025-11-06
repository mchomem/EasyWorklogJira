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
            buttonSave = new Button();
            buttonClose = new Button();
            tabControlDefault = new TabControl();
            tabPageDefault = new TabPage();
            groupBoxLocalization = new GroupBox();
            labelResetInformation = new Label();
            comboBoxLanguage = new ComboBox();
            labelLanguage = new Label();
            groupBoxWebSite = new GroupBox();
            textBoxUrlBase = new TextBox();
            labelUrlBase = new Label();
            groupBoxDailyMeetingSchedule = new GroupBox();
            labelWarningRule = new Label();
            maskedTextBoxEndTime = new MaskedTextBox();
            labelEndTime = new Label();
            maskedTextBoxStartTime = new MaskedTextBox();
            labelStartTime = new Label();
            groupBoxJiraAccessCredentials = new GroupBox();
            buttonToogleHideToken = new Button();
            textBoxToken = new TextBox();
            labelEmail = new Label();
            linkLabel = new LinkLabel();
            textBoxEmail = new TextBox();
            labelInformationToken = new Label();
            labelToken = new Label();
            tabPageJiraQueries = new TabPage();
            labelNote = new Label();
            textBoxCommonAndActiveSprintIssues = new TextBox();
            labelCommonAndActiveSprintIssues = new Label();
            tabControlDefault.SuspendLayout();
            tabPageDefault.SuspendLayout();
            groupBoxLocalization.SuspendLayout();
            groupBoxWebSite.SuspendLayout();
            groupBoxDailyMeetingSchedule.SuspendLayout();
            groupBoxJiraAccessCredentials.SuspendLayout();
            tabPageJiraQueries.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(444, 511);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 16;
            buttonSave.Text = "Salvar";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(363, 511);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 15;
            buttonClose.Text = "Fechar";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // tabControlDefault
            // 
            tabControlDefault.Controls.Add(tabPageDefault);
            tabControlDefault.Controls.Add(tabPageJiraQueries);
            tabControlDefault.Location = new Point(12, 12);
            tabControlDefault.Name = "tabControlDefault";
            tabControlDefault.SelectedIndex = 0;
            tabControlDefault.Size = new Size(511, 483);
            tabControlDefault.TabIndex = 18;
            // 
            // tabPageDefault
            // 
            tabPageDefault.Controls.Add(groupBoxLocalization);
            tabPageDefault.Controls.Add(groupBoxWebSite);
            tabPageDefault.Controls.Add(groupBoxDailyMeetingSchedule);
            tabPageDefault.Controls.Add(groupBoxJiraAccessCredentials);
            tabPageDefault.Location = new Point(4, 24);
            tabPageDefault.Name = "tabPageDefault";
            tabPageDefault.Padding = new Padding(3);
            tabPageDefault.Size = new Size(503, 455);
            tabPageDefault.TabIndex = 0;
            tabPageDefault.Text = "Padrão";
            tabPageDefault.UseVisualStyleBackColor = true;
            // 
            // groupBoxLocalization
            // 
            groupBoxLocalization.Controls.Add(labelResetInformation);
            groupBoxLocalization.Controls.Add(comboBoxLanguage);
            groupBoxLocalization.Controls.Add(labelLanguage);
            groupBoxLocalization.Location = new Point(18, 370);
            groupBoxLocalization.Name = "groupBoxLocalization";
            groupBoxLocalization.Size = new Size(462, 74);
            groupBoxLocalization.TabIndex = 14;
            groupBoxLocalization.TabStop = false;
            groupBoxLocalization.Text = "Localização";
            // 
            // labelResetInformation
            // 
            labelResetInformation.AutoSize = true;
            labelResetInformation.Location = new Point(224, 36);
            labelResetInformation.Name = "labelResetInformation";
            labelResetInformation.Size = new Size(117, 15);
            labelResetInformation.TabIndex = 2;
            labelResetInformation.Text = "OBS: precisa reiniciar";
            // 
            // comboBoxLanguage
            // 
            comboBoxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLanguage.FormattingEnabled = true;
            comboBoxLanguage.Location = new Point(84, 33);
            comboBoxLanguage.Name = "comboBoxLanguage";
            comboBoxLanguage.Size = new Size(121, 23);
            comboBoxLanguage.TabIndex = 1;
            // 
            // labelLanguage
            // 
            labelLanguage.AutoSize = true;
            labelLanguage.Location = new Point(26, 36);
            labelLanguage.Name = "labelLanguage";
            labelLanguage.Size = new Size(47, 15);
            labelLanguage.TabIndex = 0;
            labelLanguage.Text = "Idioma:";
            // 
            // groupBoxWebSite
            // 
            groupBoxWebSite.Controls.Add(textBoxUrlBase);
            groupBoxWebSite.Controls.Add(labelUrlBase);
            groupBoxWebSite.Location = new Point(18, 18);
            groupBoxWebSite.Name = "groupBoxWebSite";
            groupBoxWebSite.Size = new Size(465, 73);
            groupBoxWebSite.TabIndex = 11;
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
            // groupBoxDailyMeetingSchedule
            // 
            groupBoxDailyMeetingSchedule.Controls.Add(labelWarningRule);
            groupBoxDailyMeetingSchedule.Controls.Add(maskedTextBoxEndTime);
            groupBoxDailyMeetingSchedule.Controls.Add(labelEndTime);
            groupBoxDailyMeetingSchedule.Controls.Add(maskedTextBoxStartTime);
            groupBoxDailyMeetingSchedule.Controls.Add(labelStartTime);
            groupBoxDailyMeetingSchedule.Location = new Point(18, 255);
            groupBoxDailyMeetingSchedule.Name = "groupBoxDailyMeetingSchedule";
            groupBoxDailyMeetingSchedule.Size = new Size(462, 109);
            groupBoxDailyMeetingSchedule.TabIndex = 13;
            groupBoxDailyMeetingSchedule.TabStop = false;
            groupBoxDailyMeetingSchedule.Text = "Horário da Daily *";
            // 
            // labelWarningRule
            // 
            labelWarningRule.AutoSize = true;
            labelWarningRule.Location = new Point(6, 80);
            labelWarningRule.Name = "labelWarningRule";
            labelWarningRule.Size = new Size(86, 15);
            labelWarningRule.TabIndex = 18;
            labelWarningRule.Text = "{Warning Rule}";
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
            // groupBoxJiraAccessCredentials
            // 
            groupBoxJiraAccessCredentials.Controls.Add(buttonToogleHideToken);
            groupBoxJiraAccessCredentials.Controls.Add(textBoxToken);
            groupBoxJiraAccessCredentials.Controls.Add(labelEmail);
            groupBoxJiraAccessCredentials.Controls.Add(linkLabel);
            groupBoxJiraAccessCredentials.Controls.Add(textBoxEmail);
            groupBoxJiraAccessCredentials.Controls.Add(labelInformationToken);
            groupBoxJiraAccessCredentials.Controls.Add(labelToken);
            groupBoxJiraAccessCredentials.Location = new Point(18, 109);
            groupBoxJiraAccessCredentials.Name = "groupBoxJiraAccessCredentials";
            groupBoxJiraAccessCredentials.Size = new Size(462, 140);
            groupBoxJiraAccessCredentials.TabIndex = 12;
            groupBoxJiraAccessCredentials.TabStop = false;
            groupBoxJiraAccessCredentials.Text = "Credenciais de Acesso do Jira";
            // 
            // buttonToogleHideToken
            // 
            buttonToogleHideToken.Image = Resource.lock_open;
            buttonToogleHideToken.Location = new Point(410, 94);
            buttonToogleHideToken.Name = "buttonToogleHideToken";
            buttonToogleHideToken.Size = new Size(27, 24);
            buttonToogleHideToken.TabIndex = 10;
            buttonToogleHideToken.UseVisualStyleBackColor = true;
            buttonToogleHideToken.Click += buttonToogleHideToken_Click;
            // 
            // textBoxToken
            // 
            textBoxToken.Location = new Point(84, 95);
            textBoxToken.Name = "textBoxToken";
            textBoxToken.PasswordChar = '●';
            textBoxToken.Size = new Size(320, 23);
            textBoxToken.TabIndex = 9;
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
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(84, 26);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(353, 23);
            textBoxEmail.TabIndex = 5;
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
            // labelToken
            // 
            labelToken.AutoSize = true;
            labelToken.Location = new Point(26, 98);
            labelToken.Name = "labelToken";
            labelToken.Size = new Size(42, 15);
            labelToken.TabIndex = 8;
            labelToken.Text = "Token:";
            // 
            // tabPageJiraQueries
            // 
            tabPageJiraQueries.Controls.Add(labelNote);
            tabPageJiraQueries.Controls.Add(textBoxCommonAndActiveSprintIssues);
            tabPageJiraQueries.Controls.Add(labelCommonAndActiveSprintIssues);
            tabPageJiraQueries.Location = new Point(4, 24);
            tabPageJiraQueries.Name = "tabPageJiraQueries";
            tabPageJiraQueries.Padding = new Padding(3);
            tabPageJiraQueries.Size = new Size(503, 455);
            tabPageJiraQueries.TabIndex = 1;
            tabPageJiraQueries.Text = "Consultas JQL";
            tabPageJiraQueries.UseVisualStyleBackColor = true;
            // 
            // labelNote
            // 
            labelNote.AutoSize = true;
            labelNote.Location = new Point(18, 163);
            labelNote.Name = "labelNote";
            labelNote.Size = new Size(39, 15);
            labelNote.TabIndex = 2;
            labelNote.Text = "{note}";
            // 
            // textBoxCommonAndActiveSprintIssues
            // 
            textBoxCommonAndActiveSprintIssues.Location = new Point(18, 44);
            textBoxCommonAndActiveSprintIssues.Multiline = true;
            textBoxCommonAndActiveSprintIssues.Name = "textBoxCommonAndActiveSprintIssues";
            textBoxCommonAndActiveSprintIssues.ScrollBars = ScrollBars.Vertical;
            textBoxCommonAndActiveSprintIssues.Size = new Size(465, 116);
            textBoxCommonAndActiveSprintIssues.TabIndex = 1;
            // 
            // labelCommonAndActiveSprintIssues
            // 
            labelCommonAndActiveSprintIssues.AutoSize = true;
            labelCommonAndActiveSprintIssues.Location = new Point(18, 26);
            labelCommonAndActiveSprintIssues.Name = "labelCommonAndActiveSprintIssues";
            labelCommonAndActiveSprintIssues.Size = new Size(223, 15);
            labelCommonAndActiveSprintIssues.TabIndex = 0;
            labelCommonAndActiveSprintIssues.Text = "Projetos comuns e dentro da sprint ativa:";
            // 
            // ConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 546);
            Controls.Add(tabControlDefault);
            Controls.Add(buttonClose);
            Controls.Add(buttonSave);
            Name = "ConfigurationForm";
            Text = "Configuração";
            tabControlDefault.ResumeLayout(false);
            tabPageDefault.ResumeLayout(false);
            groupBoxLocalization.ResumeLayout(false);
            groupBoxLocalization.PerformLayout();
            groupBoxWebSite.ResumeLayout(false);
            groupBoxWebSite.PerformLayout();
            groupBoxDailyMeetingSchedule.ResumeLayout(false);
            groupBoxDailyMeetingSchedule.PerformLayout();
            groupBoxJiraAccessCredentials.ResumeLayout(false);
            groupBoxJiraAccessCredentials.PerformLayout();
            tabPageJiraQueries.ResumeLayout(false);
            tabPageJiraQueries.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonSave;
        private Button buttonClose;
        private TabControl tabControlDefault;
        private TabPage tabPageDefault;
        private Label labelWarningRule;
        private GroupBox groupBoxWebSite;
        private TextBox textBoxUrlBase;
        private Label labelUrlBase;
        private GroupBox groupBoxDailyMeetingSchedule;
        private MaskedTextBox maskedTextBoxEndTime;
        private Label labelEndTime;
        private MaskedTextBox maskedTextBoxStartTime;
        private Label labelStartTime;
        private GroupBox groupBoxJiraAccessCredentials;
        private TextBox textBoxToken;
        private Label labelEmail;
        private LinkLabel linkLabel;
        private TextBox textBoxEmail;
        private Label labelInformationToken;
        private Label labelToken;
        private TabPage tabPageJiraQueries;
        private TextBox textBoxCommonAndActiveSprintIssues;
        private Label labelCommonAndActiveSprintIssues;
        private Label labelNote;
        private GroupBox groupBoxLocalization;
        private Label labelLanguage;
        private ComboBox comboBoxLanguage;
        private Label labelResetInformation;
        private Button buttonToogleHideToken;
    }
}