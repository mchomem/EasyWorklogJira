namespace EasyWorklogJira.Infrastructure.IoC;

public static class DependenceInjectionWindowsFormsApp
{
    public static IServiceCollection AddInfrastructureWindowsFormsApp(this IServiceCollection services, IConfiguration configuration)
    {
        #region Services

        services.AddScoped<IJiraService, JiraService>();

        #endregion

        #region External Services

        services.AddHttpClient<IJiraApiClient, JiraApiClient>(client =>
        {
            client.BaseAddress = new Uri(configuration.GetSection("JiraConnection:baseUrl").Value!);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

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
