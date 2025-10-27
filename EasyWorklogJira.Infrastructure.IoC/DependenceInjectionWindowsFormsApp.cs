namespace EasyWorklogJira.Infrastructure.IoC;

public static class DependenceInjectionWindowsFormsApp
{
    public static IServiceCollection AddInfrastructureWindowsFormsApp(this IServiceCollection services, IConfiguration configuration)
    {
        #region Serilog Configuration

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(
                path: "logs/ewj-.log",
                rollingInterval: RollingInterval.Day,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] {Message:lj}{NewLine}{Exception}",
                retainedFileCountLimit: 30,
                shared: true)
            .WriteTo.Console()
            .CreateLogger();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(dispose: true);
        });

        #endregion

        #region Services

        services.AddScoped<IJiraService, JiraService>();
        services.AddScoped<INetworkService, NetworkService>();
        services.AddScoped<ILogService, LogService>();

        #endregion

        #region External Services

        services.AddHttpClient<IJiraApiClient, JiraApiClient>(client =>
        {
            var baseUrl = configuration.GetSection("JiraConnection:baseUrl").Value!;

            if (!string.IsNullOrEmpty(baseUrl))
            {
                client.BaseAddress = new Uri(baseUrl);
            }

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

        services.AddScoped<INetworkExternalService, NetworkExternalService>();

        #endregion

        #region Localization Service

        services.AddScoped<ILocalizationService, LocalizationService>();

        #endregion

        #region Configuration

        services.AddSingleton(configuration);

        #endregion

        #region Mapster

        var config = TypeAdapterConfig.GlobalSettings;
        ProfileMapping.RegisterMappings(config);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddMapster();

        #endregion

        return services;
    }
}
