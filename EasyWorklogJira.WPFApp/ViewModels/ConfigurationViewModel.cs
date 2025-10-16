using EasyWorklogJira.Core.Application.DTOs;
using EasyWorklogJira.Core.Application.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace EasyWorklogJira.WPFApp.ViewModels;

public class ConfigurationViewModel : ViewModelBase
{
    private readonly IJiraService _jiraService;

    public ConfigurationViewModel() { }

    public ConfigurationViewModel(IJiraService jiraService)
    {
        _jiraService = jiraService;
    }

    string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
    string configFileName = "appsettings.json";

    [JsonIgnore]
    public WorklogsViewModel Parent { get; set; }

    [JsonIgnore]
    public bool IsEnabled
    {
        get
        {
            if (Parent == null)
            {
                return false;
            }

            return !Parent.IsBusy;
        }
    }

    public void LoadFromJsonFile()
    {
        string filePath = Path.Combine(appDirectory, configFileName);
        if (File.Exists(filePath))
        {
            try
            {
                string configJson = File.ReadAllText(filePath);

                var config = JsonConvert.DeserializeObject<ConfigurationViewModel>(configJson);

                Email = config.Email;
                Token = config.Token;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar carregar as configurações. Detail: {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show("Arquivo de configuração não encontrado.");
        }
    }

    public async Task LoadJiraUser()
    {
        this.User = await _jiraService.GetCurrentUserAsync(); // GetMySelft();
    }

    public void CheckConfig()
    {
        LoadFromJsonFile();

        if (string.IsNullOrWhiteSpace(Email))
        {
            MessageBox.Show("Por favor, configure seu e-mail de login.");
        }

        if (string.IsNullOrWhiteSpace(Token))
        {
            MessageBox.Show("Por favor, configure seu token de acesso.");
        }
    }

    public async Task SaveToJsonFile()
    {
        try
        {
            var task = LoadJiraUser();

            string filePath = Path.Combine(appDirectory, configFileName);
            string jsonConfig = JsonConvert.SerializeObject(this);

            File.WriteAllText(filePath, jsonConfig);

            await task;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao tentar salvar as configurações. Detail: {ex.Message}");
        }
    }

    public string Email { get; set; } // Login
    public string Token { get; set; }
    public UserDto User { get; set; }
}
