namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class UserDto
{
    [JsonPropertyName("accountId")]
    public string AccountId { get; set; } = string.Empty;

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("avatarUrls")]
    public AvatarUrlsDto AvatarUrls { get; set; } = new();
}
