namespace EasyWorklogJira.Infrastructure.ExternalService.Services;

public class NetworkExternalService : INetworkExternalService
{
    private readonly HttpClient _httpClient;
    private readonly Ping _ping;

    public NetworkExternalService(HttpClient httpClient, Ping ping)
    {
        _httpClient = httpClient;
        _httpClient.Timeout = TimeSpan.FromSeconds(3);
        _ping = ping;
    }

    public async Task<bool> IsInternetAvailableAsync()
    {
        try
        {
            var replyDNS_1 = await _ping.SendPingAsync("8.8.8.8", 3000);
            var replyDNS_2 = await _ping.SendPingAsync("8.8.4.4", 3000);
            var httpClientResponse = await _httpClient.GetAsync("http://www.google.com");

            if (replyDNS_1.Status == IPStatus.Success
                || replyDNS_2.Status == IPStatus.Success
                || httpClientResponse.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
    }
}
