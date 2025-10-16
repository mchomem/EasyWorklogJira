namespace EasyWorklogJira.Test.Functional;

public class FunctionalTestFixture : IDisposable
{
    public ServiceProvider ServiceProvider { get; private set; }

    public FunctionalTestFixture()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.test.json", optional: false)
            .Build();

        var services = new ServiceCollection();

        // Configure HttpClient
        services.AddHttpClient<IJiraApiClient, JiraApiClient>(client =>
        {
            client.BaseAddress = new Uri(configuration.GetSection("JiraConnection:baseUrl").Value!);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

        #region Services

        services.AddScoped<IJiraService, JiraService>();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddScoped<ILocalizationService, LocalizationService>();
        services.AddScoped<WorklogMaintenanceForm>();

        #endregion

        #region Mapster

        var config = TypeAdapterConfig.GlobalSettings;
        ProfileMapping.RegisterMappings(config);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddMapster();

        #endregion

        ServiceProvider = services.BuildServiceProvider();
    }

    public void Dispose()
    {
        ServiceProvider?.Dispose();
    }
}
