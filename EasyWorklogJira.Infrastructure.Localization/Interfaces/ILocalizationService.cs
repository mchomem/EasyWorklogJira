namespace EasyWorklogJira.Infrastructure.Localization.Interfaces;

public interface ILocalizationService
{
    T? GetForm<T>(string culture) where T : class;
    MainMenu? GetMainMenu(string culture);
}
