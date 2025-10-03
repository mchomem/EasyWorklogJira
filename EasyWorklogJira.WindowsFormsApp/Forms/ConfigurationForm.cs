namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class ConfigurationForm : MdiChieldFormBase
{
    private readonly string _appSettingsPath;
    private readonly ILocalizationService _localizationService;
    private readonly IConfiguration _configuration;

    public ConfigurationForm(ILocalizationService localizationService, IConfiguration configuration)
    {
        _localizationService = localizationService;
        _configuration = configuration;
        InitializeComponent();

        labelWarningRule.Text = "* Ao configurar a janela de horários da daily, consulta as tarefas do dia anterior";
        labelNote.Text = "Nota: caso a JQL não seja configurada neste campo, a seguinte JQL será utilizada:\n 'sprint in openSprints() AND assignee = currentUser() ORDER BY created ASC'";

        _appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

        GetLanguages();
        LoadAppSettings();
        GetTranslate();
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
            var lanaguage = configuration["Localization:language"];

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

            if (!string.IsNullOrEmpty(lanaguage))
                comboBoxLanguage.SelectedItem = Enum.Parse(typeof(Language), lanaguage);

            if (!string.IsNullOrEmpty(commonAndActiveSprintIssues))
                textBoxCommonAndActiveSprintIssues.Text = commonAndActiveSprintIssues;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar as configurações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void GetTranslate()
    {
        var language = _configuration.GetValue<string>("Localization:language");
        var configurationForm = _localizationService.GetForm<ConfigurationFormLocalization>(language!);

        this.Text = configurationForm.Title;

        tabPageDefault.Text = configurationForm.Control.TabPageDefault;
        groupBoxWebSite.Text = configurationForm.Control.GroupBoxWebSite;
        labelUrlBase.Text = configurationForm.Control.LabelUrlBase;

        groupBoxJiraAccessCredentials.Text = configurationForm.Control.GroupBoxJiraAccessCredentials;
        labelEmail.Text = configurationForm.Control.LabelEmail;
        labelInformationToken.Text = configurationForm.Control.LabelInformationToken;
        labelToken.Text = configurationForm.Control.LabelToken;

        groupBoxDailyMeetingSchedule.Text = configurationForm.Control.GroupBoxDailyMeetingSchedule;
        labelStartTime.Text = configurationForm.Control.LabelStartTime;
        labelEndTime.Text = configurationForm.Control.LabelEndTime;
        labelWarningRule.Text = configurationForm.Control.LabelWarningRule;

        groupBoxLocalization.Text = configurationForm.Control.GroupBoxLocalization;
        labelLanguage.Text = configurationForm.Control.LabelLanguage;

        tabPageJiraQueries.Text = configurationForm.Control.TabPageJiraQueries;
        labelCommonAndActiveSprintIssues.Text = configurationForm.Control.LabelCommonAndActiveSprintIssues;
        labelNote.Text = configurationForm.Control.LabelNote;

        buttonClose.Text = configurationForm.Control.ButtonClose;
        buttonSave.Text = configurationForm.Control.ButtonSave;
    }

    private void GetLanguages()
    {
        foreach (Language language in Enum.GetValues(typeof(Language)))
        {
            comboBoxLanguage.Items.Add(language);
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
        var language = comboBoxLanguage.SelectedItem;

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

                var updatedLocalization = new Dictionary<string, object>
                {
                    { "language", language?.ToString() ?? Language.en_US.ToString() }
                };

                // Update the values on the main JSON object
                jsonObject["JiraConnection"] = JsonDocument.Parse(JsonSerializer.Serialize(updatedJiraConnection)).RootElement;
                jsonObject["DailyMeetingSchedule"] = JsonDocument.Parse(JsonSerializer.Serialize(updatedDailyMeetingSchedule)).RootElement;
                jsonObject["JiraQueries"] = JsonDocument.Parse(JsonSerializer.Serialize(updatedJiraQueries)).RootElement;
                jsonObject["Localization"] = JsonDocument.Parse(JsonSerializer.Serialize(updatedLocalization)).RootElement;

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
