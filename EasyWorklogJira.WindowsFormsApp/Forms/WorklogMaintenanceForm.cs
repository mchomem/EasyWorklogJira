namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class WorklogMaintenanceForm : MdiChieldFormBase
{
    private readonly IJiraService _jiraService;

    // Loader components
    private Panel loaderPanel;
    private Label loaderLabel;
    private PictureBox loaderGif;

    public WorklogMaintenanceForm(IJiraService jiraService)
    {
        _jiraService = jiraService;

        var worklogListingForm = Application.OpenForms.OfType<WorklogListingForm>().FirstOrDefault();

        // If the WorklogListingForm is open, position this form relative to it.
        if (worklogListingForm != null)
        {
            // Override the default StartPosition and Location;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((worklogListingForm?.Location.Y ?? 0) + 20 + worklogListingForm?.Size.Width ?? 0, 20);
        }

        InitializeComponent();
        InitializeLoader();

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

        var worklog = new Core.Application.DTOs.Maintenance.WorklogMaintenanceDto();
        var comment = new Core.Application.DTOs.Maintenance.CommentMaintenanceDto();

        #region Preenche a lista de InnerContentAddDto

        var innerContents = new List<InnerContentMaintenanceDto>();
        var textBoxContent = textBoxIssueDescription.Text.Split(Environment.NewLine);

        foreach (var line in textBoxContent)
        {
            var innerContent = new Core.Application.DTOs.Maintenance.InnerContentMaintenanceDto
            {
                Text = line
            };

            innerContents.Add(innerContent);
        }

        #endregion

        #region Preenche a lista do ContentAddDto

        var contents = new List<ContentMaintenanceDto>();
        var content = new Core.Application.DTOs.Maintenance.ContentMaintenanceDto
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
            ShowLoader("Salvando worklog...");

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
        finally
        {
            HideLoader();
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
        try
        {
            ShowLoader("Carregando dados...");

            await LoadIssuesOnActiveSprint();

            // If editing record, load each field with recovered data.
            if (!string.IsNullOrEmpty(TransferData.IssueKey) && !string.IsNullOrEmpty(TransferData.WorklogId))
            {
                var worklog = await _jiraService.GetWorklogByIdAsync(TransferData.IssueKey, TransferData.WorklogId);

                comboBoxIssues.SelectedValue = TransferData.IssueKey;
                dateTimePickerStarted.Value = DateTime.Parse(worklog.Started, CultureInfo.InvariantCulture);
                maskedTextBoxStartTime.Text = DateTime.Parse(worklog.Started, CultureInfo.InvariantCulture).ToString("HH:mm");
                maskedTextBoxTimeSpent.Text = $"{(worklog.TimeSpentSeconds / 3600):00}:{((worklog.TimeSpentSeconds % 3600) / 60):00}";

                var commentLines = ExtractTextFromComment(worklog.Comment)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .ToList();

                textBoxIssueDescription.Text = commentLines.Any()
                    ? string.Join(Environment.NewLine, commentLines)
                    : string.Empty;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            HideLoader();
            maskedTextBoxTimeSpent.Focus();
            textBoxIssueDescription.Focus();
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

    #region Loader methods

    private void InitializeLoader()
    {
        // Crie o painel do loader
        loaderPanel = new Panel
        {
            BackColor = Color.FromArgb(200, 255, 255, 255),
            Dock = DockStyle.Fill,
            Visible = false
        };

        // Crie o PictureBox para o GIF
        loaderGif = new PictureBox
        {
            Size = new Size(80, 80),
            SizeMode = PictureBoxSizeMode.StretchImage
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
            loaderGif.BackColor = Color.LightGray;
            loaderGif.BorderStyle = BorderStyle.FixedSingle;
        }

        // Crie o label com a mensagem de carregamento
        loaderLabel = new Label
        {
            Text = "Carregando dados...",
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 12, FontStyle.Bold),
            Height = 30,
            ForeColor = Color.DarkBlue
        };

        loaderPanel.Controls.Add(loaderGif);
        loaderPanel.Controls.Add(loaderLabel);

        // Adicione o painel ao formulário
        this.Controls.Add(loaderPanel);

        // Traga o loader para frente dos outros controles
        loaderPanel.BringToFront();
    }

    private void ShowLoader(string message = "Carregando dados...")
    {
        // Atualize a mensagem do loader
        loaderLabel.Text = message;

        // Posicione o GIF no centro do formulário
        loaderGif.Location = new Point(
            (this.ClientSize.Width - loaderGif.Width) / 2,
            (this.ClientSize.Height - loaderGif.Height) / 2 - 20
        );

        // Posicione o label abaixo do GIF
        loaderLabel.Size = new Size(this.ClientSize.Width, 30);
        loaderLabel.Location = new Point(
            0,
            loaderGif.Bottom + 10
        );

        // Desabilite todos os controles do formulário exceto o loader
        SetControlsEnabled(false);

        // Mostre o loader
        loaderPanel.Visible = true;
        Application.DoEvents(); // Force a atualização da UI
    }

    private void HideLoader()
    {
        // Esconda o loader
        loaderPanel.Visible = false;

        // Reabilite todos os controles do formulário
        SetControlsEnabled(true);
    }

    private void SetControlsEnabled(bool enabled)
    {
        // Disable/Enable all controls except the loader panel
        foreach (Control control in this.Controls)
        {
            if (control != loaderPanel)
            {
                control.Enabled = enabled;
            }
        }
    }

    #endregion
}
