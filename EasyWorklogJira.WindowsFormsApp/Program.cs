namespace EasyWorklogJira.WindowsFormsApp;

public static class Program
{
    public static IConfiguration Configuration { get; private set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        try
        {
            CreateBlankAppSettingsFileIfNotExists();

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // This requires Microsoft.Extensions.Configuration.FileExtensions
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar as configurações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        ApplicationConfiguration.Initialize();

        using (ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider())
        {
            MainForm mainForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
    }

    static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<MainForm>();
        services.AddTransient<ConfigurationForm>();
        services.AddTransient<WorklogListingForm>();
        services.AddTransient<WorklogMaintenanceForm>();
        services.AddTransient<AboutForm>();
        services.AddTransient<CurrentUserForm>();
        services.AddInfrastructureWindowsFormsApp(Configuration);
    }

    private static void CreateBlankAppSettingsFileIfNotExists()
    {
        var appSettingsJsonFileName = "appsettings.json";

        if (!File.Exists(appSettingsJsonFileName))
        {
            var defaultSettings = new
            {
                JiraConnection = new
                {
                    baseUrl = string.Empty,
                    email = string.Empty,
                    token = string.Empty
                },
                DailyMeetingSchedule = new
                {
                    startTime = string.Empty,
                    endTime = string.Empty
                },
                JiraQueries = new
                {
                    commonAndActiveSprintIssues = string.Empty
                }
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonContent = JsonSerializer.Serialize(defaultSettings, options);
            File.WriteAllText(appSettingsJsonFileName, jsonContent);
        }
    }
}
