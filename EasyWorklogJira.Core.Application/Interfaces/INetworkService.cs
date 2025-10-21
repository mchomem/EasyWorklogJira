namespace EasyWorklogJira.Core.Application.Interfaces;

public interface INetworkService
{
    Task<bool> IsInternetAvailableAsync();
}
