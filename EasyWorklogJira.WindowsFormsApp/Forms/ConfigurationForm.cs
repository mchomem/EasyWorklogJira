namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class ConfigurationForm : MdiChieldFormBase
{
    private readonly string _appSettingsPath;

    public ConfigurationForm()
    {
        InitializeComponent();

        labelWarningRule.Text = "* Ao configurar a janela de horários da daily, consulta as tarefas do dia anterior";
        labelNote.Text = "Nota: caso a JQL não seja configurada neste campo, a seguinte JQL será utilizada:\n 'sprint in openSprints() AND assignee = currentUser() ORDER BY created ASC'";

        _appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
        LoadAppSettings();
    }

    private void LoadAppSettings()
    {
        try
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var urlBase = configuration["JiraConnection:baseUrl"];
            var email = configuration["JiraConnection:email"];
            var token = configuration["JiraConnection:token"];
            var startTime = configuration["DailyMeetingSchedule:startTime"];
            var endTime = configuration["DailyMeetingSchedule:endTime"];
            var commonAndActiveSprintIssues = configuration["JiraQueries:commonAndActiveSprintIssues"];

            if (!string.IsNullOrEmpty(urlBase))
                textBoxUrlBase.Text = urlBase;

            if (!string.IsNullOrEmpty(email))
                textBoxEmail.Text = email;

            if (!string.IsNullOrEmpty(token))
                textBoxToken.Text = token;

            if (!string.IsNullOrEmpty(startTime))
                maskedTextBoxStartTime.Text = startTime;

            if (!string.IsNullOrEmpty(endTime))
                maskedTextBoxEndTime.Text = endTime;

            if(!string.IsNullOrEmpty(commonAndActiveSprintIssues))
                textBoxCommonAndActiveSprintIssues.Text = commonAndActiveSprintIssues;

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar as configurações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Process.Start(new ProcessStartInfo()
        {
            FileName = "https://id.atlassian.com/manage-profile/security/api-tokens",
            UseShellExecute = true
        });
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
        #region Required fields.

        var urlBase = textBoxUrlBase.Text;
        var email = textBoxEmail.Text;
        var token = textBoxToken.Text;

        #endregion

        #region Optional fields.

        var startTime = maskedTextBoxStartTime.Text;
        var endTime = maskedTextBoxEndTime.Text;
        var commonAndActiveSprintIssues = textBoxCommonAndActiveSprintIssues.Text;

        #endregion

        if (string.IsNullOrEmpty(urlBase)
            || string.IsNullOrEmpty(email)
            || string.IsNullOrEmpty(token))
        {
            MessageBox.Show(
                "Informe a Url base, e-mail e token para configuração",
                "Atenção",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        try
        {
            // Lê o arquivo JSON existente.
            string jsonContent = File.ReadAllText(_appSettingsPath);

            // Convert o JSON para um objeto dinâmico.
            using (JsonDocument document = JsonDocument.Parse(jsonContent))
            {
                // Cria uma cópia do documento com as alterações
                var root = document.RootElement.Clone();
                var jsonObject = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(root);

                // Processa JiraConnection
                var jiraConnectionElement = jsonObject.ContainsKey("JiraConnection")
                    ? jsonObject["JiraConnection"].Clone()
                    : JsonDocument.Parse("{}").RootElement;

                var jiraConnectionObj = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jiraConnectionElement);

                var updatedJiraConnection = new Dictionary<string, object>
                {
                    { "baseUrl", urlBase },
                    { "email", email },
                    { "token", token }
                };
                
                var updatedDailyMeetingSchedule = new Dictionary<string, object>
                {
                    { "startTime", startTime },
                    { "endTime", endTime }
                };

                var updatedJiraQueries = new Dictionary<string, object>
                {
                    { "commonAndActiveSprintIssues", commonAndActiveSprintIssues }
                };

                // Update the values on the main JSON object
                jsonObject["JiraConnection"] = JsonDocument.Parse(JsonSerializer.Serialize(updatedJiraConnection)).RootElement;
                jsonObject["DailyMeetingSchedule"] = JsonDocument.Parse(JsonSerializer.Serialize(updatedDailyMeetingSchedule)).RootElement;
                jsonObject["JiraQueries"] = JsonDocument.Parse(JsonSerializer.Serialize(updatedJiraQueries)).RootElement;

                // Save updated json file
                var options = new JsonSerializerOptions { WriteIndented = true };
                string updatedJson = JsonSerializer.Serialize(jsonObject, options);
                File.WriteAllText(_appSettingsPath, updatedJson);
            }

            MessageBox.Show("Configurações salvas com sucesso!",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao salvar as configurações: {ex.Message}",
                 "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
