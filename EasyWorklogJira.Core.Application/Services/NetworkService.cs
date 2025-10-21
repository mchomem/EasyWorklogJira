namespace EasyWorklogJira.Core.Application.Services;

public class NetworkService : INetworkService
{
    private readonly INetworkExternalService _networkExternalService;

    public NetworkService(INetworkExternalService networkExternalService)
    {        
        _networkExternalService = networkExternalService;
    }

    public async Task<bool> IsInternetAvailableAsync()
    {
        var result = await _networkExternalService.IsInternetAvailableAsync();
        return result;
    }
}
