namespace EasyWorklogJira.Core.Domain.Interfaces;

public interface ILogService
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
    void LogError(Exception exception, string message, params object[] args);
    void LogDebug(string message, params object[] args);
}
