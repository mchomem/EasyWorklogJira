namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class WorklogListingForm : MdiChieldFormBase
{
    private readonly IJiraService _jiraService;
    private readonly ILocalizationService _localizationService;
    private readonly IConfiguration _configuration;

    private Panel loaderPanel;
    private Label loaderLabel;
    private PictureBox loaderGif;

    public WorklogListingForm(IJiraService jiraService, ILocalizationService localizationService, IConfiguration configuration)
    {
        _jiraService = jiraService;
        _localizationService = localizationService;
        _configuration = configuration;

        InitializeComponent();
        InitializeLoader();
        GetTranslate();
    }

    private void GetTranslate()
    {
        var language = _configuration.GetValue<string>("Localization:language");
        var worklogListingForm = _localizationService.GetForm<WorklogListingFormLocalization>(language!);

        Text = worklogListingForm.Title;
        labelResume.Text = worklogListingForm.Control.LabelResume;

        dataGridViewDayWorklogs.Columns["IssueKey"].HeaderText = worklogListingForm.Control.ColumnIssueKey;
        dataGridViewDayWorklogs.Columns["StartTime"].HeaderText = worklogListingForm.Control.ColumnStartTime;
        dataGridViewDayWorklogs.Columns["EndTime"].HeaderText = worklogListingForm.Control.ColumnEndTime;
        dataGridViewDayWorklogs.Columns["Update"].HeaderText = worklogListingForm.Control.ColumnUpdate;
        dataGridViewDayWorklogs.Columns["Delete"].HeaderText = worklogListingForm.Control.ColumnDelete;

        labelTotalHoursDay.Text = worklogListingForm.Control.LabelTotalHoursDay;
        buttonNewWorklog.Text = worklogListingForm.Control.ButtonNew;
    }

    private async Task LoadFormAsync()
    {
        buttonRefreshList.Enabled = false;

        var dateTimeNow = DateTime.Now;
        var startTime = _configuration.GetSection("DailyMeetingSchedule:startTime").Value;
        var endTime = _configuration.GetSection("DailyMeetingSchedule:endTime").Value;

        if (TimeSpan.TryParse(startTime, out var meetingStartTime) && TimeSpan.TryParse(endTime, out var meetingEndTime))
        {
            var meetingStartDateTime = dateTimeNow.Date.Add(meetingStartTime);
            var meetingEndDateTime = dateTimeNow.Date.Add(meetingEndTime);

            // If the current time is within the meeting schedule, load the previous day's worklogs.
            if (dateTimeNow >= meetingStartDateTime && dateTimeNow <= meetingEndDateTime)
            {
                await LoadWorklogsAsync(getPreviousDay: true);
            }
            else
            {
                await LoadWorklogsAsync();
            }
        }
        else
        {
            await LoadWorklogsAsync();
        }

        buttonRefreshList.Enabled = true;
    }

    private async Task LoadWorklogsAsync(bool getPreviousDay = false)
    {
        try
        {
            ShowLoader();

            if (getPreviousDay)
            {
                var dateTimeNow = DateTime.Now;

                // If today is Monday, go back to Friday
                if (dateTimeNow.DayOfWeek == DayOfWeek.Monday)
                {
                    var previousFriday = monthCalendar.SelectionStart.AddDays(-3);
                    monthCalendar.SelectionStart = previousFriday;
                }
                else
                {
                    // For other days, just go back one day
                    var previousDay = monthCalendar.SelectionStart.AddDays(-1);
                    monthCalendar.SelectionStart = previousDay;
                }
            }

            var selectedDate = monthCalendar.SelectionStart;
            labelResumeValue.Text = $"{selectedDate:dd/MM/yyyy}";
            var selectedDateTimeOffiset = new DateTimeOffset(selectedDate);
            var issues = await _jiraService.GetIssuesWithWorklogsByDateTimeAsync(selectedDateTimeOffiset);

            dataGridViewDayWorklogs.Rows.Clear();

            var hoursRecorded = new List<(DateTimeOffset start, DateTimeOffset end, string issueKey)>();
            var issuesKeys = issues.Select(i => i.Key);
            var email = _configuration.GetSection("JiraConnection:Email").Value!;
            var worklogs = await _jiraService.GetIssueWorklogsAsync(issuesKeys, selectedDateTimeOffiset, email);

            if (worklogs != null && worklogs.Any())
            {
                foreach (var worklog in worklogs)
                {
                    DateTimeOffset endTime = worklog.Started.AddSeconds(worklog.TimeSpentSeconds);
                    var workDescriptions = ExtractTextFromComment(worklog.Comment);

                    dataGridViewDayWorklogs.Rows.Add(worklog.Id, worklog.IssueKey, $"{worklog.Started:HH:mm}", $"{endTime:HH:mm}");
                    hoursRecorded.Add((worklog.Started, endTime, worklog.IssueKey));
                }
            }

            var totalHours = hoursRecorded.Sum(hr => (hr.end - hr.start).TotalHours);
            var totalTime = TimeSpan.FromHours(totalHours);

            if (totalHours < 6)
            {
                labelTotalHoursDayValue.BackColor = System.Drawing.Color.Red;
                labelTotalHoursDayValue.ForeColor = System.Drawing.Color.White;
            }
            else if (totalHours >= 6 && totalHours <= 7)
            {
                labelTotalHoursDayValue.BackColor = System.Drawing.Color.Yellow;
                labelTotalHoursDayValue.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                labelTotalHoursDayValue.BackColor = System.Drawing.Color.Green;
                labelTotalHoursDayValue.ForeColor = System.Drawing.Color.White;
            }

            labelTotalHoursDayValue.Text = $"{(int)totalTime.TotalHours:D2}:{totalTime.Minutes:D2}";
        }
        finally
        {
            buttonRefreshList.Enabled = true;
            HideLoader();
        }
    }

    private async void WorklogForm_LoadAsync(object sender, EventArgs e)
    {
        await LoadFormAsync();
    }

    private async void monthCalendar_DateSelectedAsync(object sender, DateRangeEventArgs e)
    {
        await LoadWorklogsAsync();
    }

    private async void dataGridViewDayWorklogs_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
    {
        var worklogId = dataGridViewDayWorklogs.Rows[e.RowIndex].Cells["WorklogId"].Value?.ToString()!;
        var issueId = dataGridViewDayWorklogs.Rows[e.RowIndex].Cells["IssueKey"].Value?.ToString()!;

        // Ignore header clicks
        if (e.RowIndex < 0) return;

        if (e.ColumnIndex == 1 && e.RowIndex >= 0)
        {
            var issueKey = dataGridViewDayWorklogs.Rows[e.RowIndex].Cells["IssueKey"].Value?.ToString()!;
            var jiraUrl = $"{_configuration.GetSection("JiraConnection:baseUrl").Value}/browse/{issueKey}";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = jiraUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível abrir o link: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        if (dataGridViewDayWorklogs.Columns[e.ColumnIndex].Name == "Update")
        {
            MainForm mainForm = (this.MdiParent as MainForm)!;

            if (mainForm is not null)
            {
                // Passar os dados diretamente para o formulário de manutenção
                var worklogMaintenanceForm = new WorklogMaintenanceForm(_jiraService, _localizationService, _configuration, issueId, worklogId);
                worklogMaintenanceForm.MdiParent = mainForm;
                worklogMaintenanceForm.Show();

                Close();
            }
        }
        else if (dataGridViewDayWorklogs.Columns[e.ColumnIndex].Name == "Delete")
        {
            var resultDialog = MessageBox.Show("Tem certeza que deseja excluir este registro de atividade?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultDialog == DialogResult.Yes)
            {
                await _jiraService.DeleteWorklogAsync(issueId, worklogId);

                MessageBox.Show($"Registro id: {worklogId} de tarefa excluída.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadWorklogsAsync();
            }
        }
    }

    private async void buttonRefreshList_Click(object sender, EventArgs e)
    {
        await LoadFormAsync();
    }

    private void buttonNewWorklog_Click(object sender, EventArgs e)
    {
        // Get the MainForm (MDI Parent)
        MainForm mainForm = (this.MdiParent as MainForm)!;

        if (mainForm is not null)
        {
            // Criar novo worklog sem parâmetros (modo inserção)
            var worklogMaintenanceForm = new WorklogMaintenanceForm(_jiraService, _localizationService, _configuration);
            worklogMaintenanceForm.MdiParent = mainForm;
            worklogMaintenanceForm.Show();
        }
    }

    private static List<string> ExtractTextFromComment(CommentDto comment)
    {
        if (comment == null || comment.Content == null)
            return new();

        var comments = new List<string>();

        if (comment.Type == "doc" && comment.Version == 1)
        {
            foreach (var outerContent in comment.Content)
            {
                if (outerContent.Type == ContentType.OrderedList.GetDescription())
                {
                    if (outerContent.Content != null)
                    {
                        foreach (var innerContent in outerContent.Content)
                        {
                            if (innerContent.Content != null)
                            {
                                foreach (var textContent in innerContent.Content)
                                {
                                    foreach (var contentParagraph in textContent.Content)
                                    {
                                        if (contentParagraph.Type == "text" && !string.IsNullOrEmpty(contentParagraph.Text))
                                        {
                                            comments.Add(contentParagraph.Text);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (outerContent.Type == ContentType.Paragraph.GetDescription())
                {
                    foreach (var contentParagraph in outerContent?.Content ?? new List<NestedContentDto>())
                    {
                        if (contentParagraph.Type == "text" && !string.IsNullOrEmpty(contentParagraph.Text))
                        {
                            comments.Add(contentParagraph.Text);
                        }
                    }
                }
            }
        }

        return comments;
    }

    #region Loader methods

    private void InitializeLoader()
    {
        // Crie o painel do loader
        loaderPanel = new Panel
        {
            BackColor = Color.FromArgb(200, 255, 255, 255),
            Dock = DockStyle.None,
            Visible = false
        };

        // Crie o PictureBox para o GIF - corrigindo o nome do recurso
        loaderGif = new PictureBox
        {
            Size = new Size(80, 80),
            SizeMode = PictureBoxSizeMode.StretchImage,
            Image = EasyWorklogJira.WindowsFormsApp.Resource.Rolling1x_1_0s_200px_200px
        };

        try
        {
            // Use o nome correto do recurso conforme definido no .resx
            loaderGif.Image = EasyWorklogJira.WindowsFormsApp.Resource.Rolling1x_1_0s_200px_200px;
        }
        catch (Exception ex)
        {
            // Em caso de erro, crie um loader alternativo simples
            Console.WriteLine($"Erro ao carregar o GIF: {ex.Message}");
            loaderGif.BackColor = Color.Transparent;
        }

        // Crie o label com a mensagem de carregamento
        loaderLabel = new Label
        {
            Text = "Consultando, aguarde...",
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            Height = 30
        };

        loaderPanel.Controls.Add(loaderGif);

        // Adicione o label ao painel
        loaderPanel.Controls.Add(loaderLabel);

        // Adicione o painel ao formulário
        this.Controls.Add(loaderPanel);

        // Traga o loader para frente dos outros controles
        loaderPanel.BringToFront();
    }

    // Adicione este método para mostrar o loader
    private void ShowLoader()
    {
        // Posicione o painel do loader sobre o DataGridView
        loaderPanel.Size = dataGridViewDayWorklogs.Size;
        loaderPanel.Location = dataGridViewDayWorklogs.PointToScreen(Point.Empty);
        loaderPanel.Location = this.PointToClient(loaderPanel.Location);

        // Posicione o GIF no centro do painel
        loaderGif.Location = new Point(
            (loaderPanel.Width - loaderGif.Width) / 2,
            (loaderPanel.Height - loaderGif.Height) / 2 - 20 // Um pouco acima do centro
        );

        // Posicione o label abaixo do GIF
        loaderLabel.Size = new Size(loaderPanel.Width, 30);
        loaderLabel.Location = new Point(
            0,
            loaderGif.Bottom + 10
        );

        // Mostre o loader
        loaderPanel.Visible = true;
        Application.DoEvents(); // Force a atualização da UI
    }

    // Adicione este método para esconder o loader
    private void HideLoader()
    {
        // Esconda o loader
        loaderPanel.Visible = false;
    }

    #endregion
}
