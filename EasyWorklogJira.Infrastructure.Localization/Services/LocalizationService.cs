namespace EasyWorklogJira.Infrastructure.Localization.Services;

public class LocalizationService : ILocalizationService
{
    private readonly Root _root;

    public LocalizationService()
    {
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "Translations.json");

        if (!File.Exists(jsonPath))
            throw new FileNotFoundException($"Localization file not found at path: {jsonPath}");

        var options = new System.Text.Json.JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = System.Text.Json.JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };

        var json = File.ReadAllText(jsonPath);
        _root = System.Text.Json.JsonSerializer.Deserialize<Root>(json, options)
                ?? throw new InvalidOperationException("Failed to deserialize localization JSON.");
    }

    /// <summary>
    /// Obtém a tradução de acordo com a cultura e tipo de form desejado.
    /// </summary>
    public T? GetForm<T>(string culture) where T : class
    {
        return culture switch
        {
            "en_US" => ResolveForm<T>(_root.EnUS.Form),
            "pt_BR" => ResolveForm<T>(_root.PtBR.Form),
            _ => throw new NotSupportedException($"Culture '{culture}' not supported.")
        };
    }

    /// <summary>
    /// Atalho para pegar textos de menus principais.
    /// </summary>
    public MainMenu? GetMainMenu(string culture)
    {
        return culture switch
        {
            "en_US" => _root.EnUS.Form.MainForm.MainMenu,
            "pt_BR" => _root.PtBR.Form.MainForm.MainMenu,
            _ => null
        };
    }

    private T? ResolveForm<T>(FormLocalization form) where T : class
    {
        // Verifica cada propriedade do objeto Form
        var property = typeof(FormLocalization).GetProperties().FirstOrDefault(p => p.PropertyType == typeof(T));

        if (property != null)
            return property.GetValue(form) as T;

        return null;
    }
}
