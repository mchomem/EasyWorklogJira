namespace EasyWorklogJira.WindowsFormsApp.Forms
{
    partial class WorklogListingForm
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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            monthCalendar = new MonthCalendar();
            dataGridViewDayWorklogs = new DataGridView();
            WorklogId = new DataGridViewTextBoxColumn();
            IssueKey = new DataGridViewLinkColumn();
            StartTime = new DataGridViewTextBoxColumn();
            EndTime = new DataGridViewTextBoxColumn();
            Update = new DataGridViewImageColumn();
            Delete = new DataGridViewImageColumn();
            labelResume = new Label();
            labelTotalHoursDay = new Label();
            labelTotalHoursDayValue = new Label();
            buttonNewWorklog = new Button();
            labelResumeValue = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDayWorklogs).BeginInit();
            SuspendLayout();
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(47, 18);
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 0;
            monthCalendar.DateSelected += monthCalendar_DateSelected;
            // 
            // dataGridViewDayWorklogs
            // 
            dataGridViewDayWorklogs.AllowUserToAddRows = false;
            dataGridViewDayWorklogs.AllowUserToDeleteRows = false;
            dataGridViewDayWorklogs.AllowUserToResizeColumns = false;
            dataGridViewDayWorklogs.AllowUserToResizeRows = false;
            dataGridViewDayWorklogs.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewDayWorklogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDayWorklogs.Columns.AddRange(new DataGridViewColumn[] { WorklogId, IssueKey, StartTime, EndTime, Update, Delete });
            dataGridViewDayWorklogs.Location = new Point(18, 240);
            dataGridViewDayWorklogs.Name = "dataGridViewDayWorklogs";
            dataGridViewDayWorklogs.ReadOnly = true;
            dataGridViewDayWorklogs.RowHeadersVisible = false;
            dataGridViewDayWorklogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDayWorklogs.Size = new Size(292, 180);
            dataGridViewDayWorklogs.TabIndex = 1;
            dataGridViewDayWorklogs.CellContentClick += dataGridViewDayWorklogs_CellContentClick;
            // 
            // WorklogId
            // 
            WorklogId.HeaderText = "WorklogId";
            WorklogId.Name = "WorklogId";
            WorklogId.ReadOnly = true;
            WorklogId.Visible = false;
            // 
            // IssueKey
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            IssueKey.DefaultCellStyle = dataGridViewCellStyle13;
            IssueKey.FillWeight = 70F;
            IssueKey.HeaderText = "Tarefa";
            IssueKey.Name = "IssueKey";
            IssueKey.ReadOnly = true;
            IssueKey.Resizable = DataGridViewTriState.False;
            IssueKey.SortMode = DataGridViewColumnSortMode.Automatic;
            IssueKey.Width = 70;
            // 
            // StartTime
            // 
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            StartTime.DefaultCellStyle = dataGridViewCellStyle14;
            StartTime.FillWeight = 50F;
            StartTime.HeaderText = "Início";
            StartTime.Name = "StartTime";
            StartTime.ReadOnly = true;
            StartTime.Resizable = DataGridViewTriState.False;
            StartTime.Width = 50;
            // 
            // EndTime
            // 
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            EndTime.DefaultCellStyle = dataGridViewCellStyle15;
            EndTime.FillWeight = 50F;
            EndTime.HeaderText = "Fim";
            EndTime.Name = "EndTime";
            EndTime.ReadOnly = true;
            EndTime.Resizable = DataGridViewTriState.False;
            EndTime.Width = 50;
            // 
            // Update
            // 
            Update.FillWeight = 60F;
            Update.HeaderText = "Atualizar";
            Update.Image = Resource.page_white_edit;
            Update.Name = "Update";
            Update.ReadOnly = true;
            Update.Width = 60;
            // 
            // Delete
            // 
            Delete.FillWeight = 60F;
            Delete.HeaderText = "Excluir";
            Delete.Image = Resource.cross;
            Delete.Name = "Delete";
            Delete.ReadOnly = true;
            Delete.Width = 60;
            // 
            // labelResume
            // 
            labelResume.Font = new Font("Segoe UI", 12F);
            labelResume.Location = new Point(18, 195);
            labelResume.Name = "labelResume";
            labelResume.Size = new Size(129, 32);
            labelResume.TabIndex = 2;
            labelResume.Text = "Resumo do dia";
            labelResume.TextAlign = ContentAlignment.MiddleRight;
            // 
            // labelTotalHoursDay
            // 
            labelTotalHoursDay.AutoSize = true;
            labelTotalHoursDay.Font = new Font("Segoe UI", 12F);
            labelTotalHoursDay.Location = new Point(18, 436);
            labelTotalHoursDay.Name = "labelTotalHoursDay";
            labelTotalHoursDay.Size = new Size(143, 21);
            labelTotalHoursDay.TabIndex = 3;
            labelTotalHoursDay.Text = "Horas trabalhadas: ";
            // 
            // labelTotalHoursDayValue
            // 
            labelTotalHoursDayValue.AutoSize = true;
            labelTotalHoursDayValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTotalHoursDayValue.Location = new Point(167, 436);
            labelTotalHoursDayValue.Name = "labelTotalHoursDayValue";
            labelTotalHoursDayValue.Size = new Size(50, 21);
            labelTotalHoursDayValue.TabIndex = 4;
            labelTotalHoursDayValue.Text = "00:00";
            // 
            // buttonNewWorklog
            // 
            buttonNewWorklog.Location = new Point(235, 533);
            buttonNewWorklog.Name = "buttonNewWorklog";
            buttonNewWorklog.Size = new Size(75, 23);
            buttonNewWorklog.TabIndex = 5;
            buttonNewWorklog.Text = "Novo";
            buttonNewWorklog.UseVisualStyleBackColor = true;
            buttonNewWorklog.Click += buttonNewWorklog_Click;
            // 
            // labelResumeValue
            // 
            labelResumeValue.Font = new Font("Segoe UI", 12F);
            labelResumeValue.Location = new Point(150, 195);
            labelResumeValue.Name = "labelResumeValue";
            labelResumeValue.Size = new Size(160, 32);
            labelResumeValue.TabIndex = 6;
            labelResumeValue.Text = "00/00/0000";
            labelResumeValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // WorklogListingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 568);
            Controls.Add(buttonNewWorklog);
            Controls.Add(labelTotalHoursDayValue);
            Controls.Add(labelTotalHoursDay);
            Controls.Add(labelResume);
            Controls.Add(dataGridViewDayWorklogs);
            Controls.Add(monthCalendar);
            Controls.Add(labelResumeValue);
            Name = "WorklogListingForm";
            Text = "Registro de tarefas";
            Load += WorklogForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDayWorklogs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar monthCalendar;
        private DataGridView dataGridViewDayWorklogs;
        private Label labelResume;
        private Label labelTotalHoursDay;
        private Label labelTotalHoursDayValue;
        private Button buttonNewWorklog;
        private DataGridViewTextBoxColumn WorklogId;
        private DataGridViewLinkColumn IssueKey;
        private DataGridViewTextBoxColumn StartTime;
        private DataGridViewTextBoxColumn EndTime;
        private DataGridViewImageColumn Update;
        private DataGridViewImageColumn Delete;
        private Label labelResumeValue;
    }
}