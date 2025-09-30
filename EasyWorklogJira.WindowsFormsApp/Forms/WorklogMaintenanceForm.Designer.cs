namespace EasyWorklogJira.WindowsFormsApp.Forms
{
    partial class WorklogMaintenanceForm
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
            dateTimePickerStarted = new DateTimePicker();
            comboBoxIssues = new ComboBox();
            labelIssue = new Label();
            labelDate = new Label();
            labelTimeSpent = new Label();
            labelWorklogDescription = new Label();
            textBoxIssueDescription = new TextBox();
            maskedTextBoxTimeSpent = new MaskedTextBox();
            maskedTextBoxStartTime = new MaskedTextBox();
            buttonSave = new Button();
            labelStartTime = new Label();
            labelEndTime = new Label();
            maskedTextBoxEndTime = new MaskedTextBox();
            SuspendLayout();
            // 
            // dateTimePickerStarted
            // 
            dateTimePickerStarted.Format = DateTimePickerFormat.Short;
            dateTimePickerStarted.Location = new Point(135, 54);
            dateTimePickerStarted.Name = "dateTimePickerStarted";
            dateTimePickerStarted.Size = new Size(85, 23);
            dateTimePickerStarted.TabIndex = 3;
            // 
            // comboBoxIssues
            // 
            comboBoxIssues.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIssues.FormattingEnabled = true;
            comboBoxIssues.Location = new Point(135, 25);
            comboBoxIssues.Name = "comboBoxIssues";
            comboBoxIssues.Size = new Size(347, 23);
            comboBoxIssues.TabIndex = 1;
            // 
            // labelIssue
            // 
            labelIssue.AutoSize = true;
            labelIssue.Location = new Point(16, 28);
            labelIssue.Name = "labelIssue";
            labelIssue.Size = new Size(42, 15);
            labelIssue.TabIndex = 0;
            labelIssue.Text = "Tarefa:";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(16, 57);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(34, 15);
            labelDate.TabIndex = 2;
            labelDate.Text = "Data:";
            // 
            // labelTimeSpent
            // 
            labelTimeSpent.AutoSize = true;
            labelTimeSpent.Location = new Point(16, 115);
            labelTimeSpent.Name = "labelTimeSpent";
            labelTimeSpent.Size = new Size(113, 15);
            labelTimeSpent.TabIndex = 5;
            labelTimeSpent.Text = "Tempo gasto (h/m):";
            // 
            // labelWorklogDescription
            // 
            labelWorklogDescription.AutoSize = true;
            labelWorklogDescription.Location = new Point(16, 142);
            labelWorklogDescription.Name = "labelWorklogDescription";
            labelWorklogDescription.Size = new Size(128, 15);
            labelWorklogDescription.TabIndex = 7;
            labelWorklogDescription.Text = "Descrição da atividade:";
            // 
            // textBoxIssueDescription
            // 
            textBoxIssueDescription.Location = new Point(16, 160);
            textBoxIssueDescription.Multiline = true;
            textBoxIssueDescription.Name = "textBoxIssueDescription";
            textBoxIssueDescription.Size = new Size(466, 84);
            textBoxIssueDescription.TabIndex = 8;
            // 
            // maskedTextBoxTimeSpent
            // 
            maskedTextBoxTimeSpent.Location = new Point(135, 112);
            maskedTextBoxTimeSpent.Mask = "00:00";
            maskedTextBoxTimeSpent.Name = "maskedTextBoxTimeSpent";
            maskedTextBoxTimeSpent.Size = new Size(36, 23);
            maskedTextBoxTimeSpent.TabIndex = 6;
            maskedTextBoxTimeSpent.Leave += maskedTextBoxTimeSpent_Leave;
            // 
            // maskedTextBoxStartTime
            // 
            maskedTextBoxStartTime.Location = new Point(136, 83);
            maskedTextBoxStartTime.Mask = "00:00";
            maskedTextBoxStartTime.Name = "maskedTextBoxStartTime";
            maskedTextBoxStartTime.Size = new Size(35, 23);
            maskedTextBoxStartTime.TabIndex = 4;
            maskedTextBoxStartTime.Leave += maskedTextBoxStartTime_Leave;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(407, 250);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 9;
            buttonSave.Text = "Salvar";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelStartTime
            // 
            labelStartTime.AutoSize = true;
            labelStartTime.Location = new Point(16, 86);
            labelStartTime.Name = "labelStartTime";
            labelStartTime.Size = new Size(70, 15);
            labelStartTime.TabIndex = 10;
            labelStartTime.Text = "Hora inicial:";
            // 
            // labelEndTime
            // 
            labelEndTime.AutoSize = true;
            labelEndTime.Location = new Point(206, 86);
            labelEndTime.Name = "labelEndTime";
            labelEndTime.Size = new Size(62, 15);
            labelEndTime.TabIndex = 11;
            labelEndTime.Text = "Hora final:";
            // 
            // maskedTextBoxEndTime
            // 
            maskedTextBoxEndTime.Location = new Point(276, 83);
            maskedTextBoxEndTime.Mask = "00:00";
            maskedTextBoxEndTime.Name = "maskedTextBoxEndTime";
            maskedTextBoxEndTime.ReadOnly = true;
            maskedTextBoxEndTime.Size = new Size(35, 23);
            maskedTextBoxEndTime.TabIndex = 12;
            // 
            // WorklogMaintenanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 286);
            Controls.Add(maskedTextBoxEndTime);
            Controls.Add(labelEndTime);
            Controls.Add(labelStartTime);
            Controls.Add(buttonSave);
            Controls.Add(maskedTextBoxStartTime);
            Controls.Add(maskedTextBoxTimeSpent);
            Controls.Add(textBoxIssueDescription);
            Controls.Add(labelWorklogDescription);
            Controls.Add(labelTimeSpent);
            Controls.Add(labelDate);
            Controls.Add(labelIssue);
            Controls.Add(comboBoxIssues);
            Controls.Add(dateTimePickerStarted);
            Name = "WorklogMaintenanceForm";
            Text = "Registro de Tarefas";
            Load += WorklogMaintenanceForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerStarted;
        private ComboBox comboBoxIssues;
        private Label labelIssue;
        private Label labelDate;
        private Label labelTimeSpent;
        private Label labelWorklogDescription;
        private TextBox textBoxIssueDescription;
        private MaskedTextBox maskedTextBoxTimeSpent;
        private MaskedTextBox maskedTextBoxStartTime;
        private Button buttonSave;
        private Label labelStartTime;
        private Label labelEndTime;
        private MaskedTextBox maskedTextBoxEndTime;
    }
}