namespace EasyWorklogJira.Core.Application.Interfaces;

public interface INetworkExternalService
{
    Task<bool> IsInternetAvailableAsync();
}
