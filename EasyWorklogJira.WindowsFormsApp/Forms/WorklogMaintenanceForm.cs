namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class WorklogMaintenanceForm : MdiChieldFormBase
{
    private readonly IJiraService _jiraService;

    public WorklogMaintenanceForm(IJiraService jiraService)
    {
        _jiraService = jiraService;
        InitializeComponent();

        maskedTextBoxStartTime.Text = DateTime.Now.ToString("HH:mm");
    }

    public async Task LoadIssuesOnActiveSprint()
    {
        var issuesActiveProjects = await _jiraService.GetIssuesActiveProjectsAsync();

        comboBoxIssues.DataSource = issuesActiveProjects.ToList();
        comboBoxIssues.DisplayMember = "DisplayIssueText";
        comboBoxIssues.ValueMember = "Key";
    }

    private async Task Save()
    {
        if (comboBoxIssues.SelectedItem is null
        || !maskedTextBoxStartTime.MaskCompleted
        || !maskedTextBoxTimeSpent.MaskCompleted
        || string.IsNullOrEmpty(textBoxIssueDescription.Text))
        {
            MessageBox.Show("Por favor, preencha todos os campos.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Validar se o maskedTextBoxTimeSpent contém um valor válido
        if (!maskedTextBoxTimeSpent.MaskFull || !maskedTextBoxTimeSpent.MaskCompleted)
        {
            MessageBox.Show("Por favor, informe o tempo gasto no formato hh:mm.", "Tempo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            maskedTextBoxTimeSpent.Focus();
            return;
        }

        // Obter horas e minutos do maskedTextBox
        if (!TimeSpan.TryParse(maskedTextBoxTimeSpent.Text, out TimeSpan timeSpent))
        {
            MessageBox.Show("Formato de tempo inválido. Use o formato hh:mm.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            maskedTextBoxTimeSpent.Focus();
            return;
        }

        // Calcular o tempo em segundos (horas * 3600 + minutos * 60)
        long timeSpentSeconds = (long)timeSpent.TotalSeconds;

        var worklog = new Core.Application.DTOs.Add.WorklogAddDto();
        var comment = new Core.Application.DTOs.Add.CommentAddDto();

        #region Preenche a lista de InnerContentAddDto

        var innerContents = new List<InnerContentAddDto>();
        var textBoxContent = textBoxIssueDescription.Text.Split(Environment.NewLine);

        foreach (var line in textBoxContent)
        {
            var innerContent = new Core.Application.DTOs.Add.InnerContentAddDto
            {
                Text = line
            };

            innerContents.Add(innerContent);
        }

        #endregion

        #region Preenche a lista do ContentAddDto

        var contents = new List<ContentAddDto>();
        var content = new Core.Application.DTOs.Add.ContentAddDto
        {
            Content = innerContents
        };
        contents.Add(content);
        comment.Content = contents;

        #endregion

        comment.Content = contents;
        worklog.Comment = comment;

        if (!TimeSpan.TryParse(maskedTextBoxTimeSpent.Text, out TimeSpan timeSpendParsed))
        {
            MessageBox.Show($"Valor inválido para Tempo Gasto.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DateTime dateTime = dateTimePickerStarted.Value.Date;
        TimeSpan timeOfDay = TimeSpan.Parse(maskedTextBoxStartTime.Text);
        dateTime = dateTime.Add(timeOfDay);

        worklog.Started = DateTimeToIso8601Jira(dateTime);

        // Atribuir o tempo calculado em segundos
        worklog.TimeSpentSeconds = timeSpentSeconds;

        try
        {
            var selectedIssue = comboBoxIssues?.SelectedValue?.ToString()!;

            if (string.IsNullOrEmpty(TransferData.IssueKey) && string.IsNullOrEmpty(TransferData.WorklogId))
                await _jiraService.AddWorklogAsync(selectedIssue, worklog);
            else
                await _jiraService.UpdateWorklogAsync(selectedIssue, TransferData.WorklogId, worklog);

            MessageBox.Show("Worklog registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao registrar o worklog: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SetFinalTime()
    {
        if (maskedTextBoxStartTime.MaskCompleted && maskedTextBoxTimeSpent.MaskCompleted)
        {
            DateTime dateTime = dateTimePickerStarted.Value.Date;
            TimeSpan timeOfDay = TimeSpan.Parse(maskedTextBoxStartTime.Text);
            dateTime = dateTime.Add(timeOfDay);

            TimeSpan timeSpent = TimeSpan.Parse(maskedTextBoxTimeSpent.Text);
            TimeSpan finalHour = timeOfDay.Add(timeSpent);
            maskedTextBoxEndTime.Text = $"{finalHour.Hours:00}{finalHour.Minutes:00}";
        }
    }

    private static string DateTimeToIso8601Jira(DateTime dateTime)
    {
        var dateTimeIso8601 = dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture);
        var dateTimeIso8061Fused = dateTime.ToString("zzz", CultureInfo.InvariantCulture).Replace(":", string.Empty);
        return $"{dateTimeIso8601}{dateTimeIso8061Fused}";
    }

    private async void WorklogMaintenanceForm_Load(object sender, EventArgs e)
    {
        await LoadIssuesOnActiveSprint();

        // TODO: create a loader spinner while loading data or disable the form.
        // If editing record, load each field with recovered data.
        if (!string.IsNullOrEmpty(TransferData.IssueKey) && !string.IsNullOrEmpty(TransferData.WorklogId))
        {
            var worklog = await _jiraService.GetWorklogByIdAsync(TransferData.IssueKey, TransferData.WorklogId);

            comboBoxIssues.SelectedValue = TransferData.IssueKey;
            dateTimePickerStarted.Value = DateTime.Parse(worklog.Started, CultureInfo.InvariantCulture);
            maskedTextBoxStartTime.Text = DateTime.Parse(worklog.Started, CultureInfo.InvariantCulture).ToString("HH:mm");
            maskedTextBoxTimeSpent.Text = $"{(worklog.TimeSpentSeconds / 3600):00}:{((worklog.TimeSpentSeconds % 3600) / 60):00}";
            maskedTextBoxTimeSpent.Focus();
            textBoxIssueDescription.Focus();

            var commentLines = ExtractTextFromComment(worklog.Comment)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();

            textBoxIssueDescription.Text = commentLines.Any()
                ? string.Join(Environment.NewLine, commentLines)
                : string.Empty;
        }
    }

    private async void buttonSave_Click(object sender, EventArgs e)
    {
        await Save();
    }

    private void maskedTextBoxStartTime_Leave(object sender, EventArgs e)
    {
        SetFinalTime();
    }

    private void maskedTextBoxTimeSpent_Leave(object sender, EventArgs e)
    {
        SetFinalTime();
    }

    private void WorklogMaintenanceForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Clear transfer data before closing this form.
        TransferData.IssueKey = string.Empty;
        TransferData.WorklogId = string.Empty;
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
}
