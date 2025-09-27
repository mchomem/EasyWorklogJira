namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class AuthorDto
{
    [JsonPropertyName("accountId")]
    public string AccountId { get; set; }
    
    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }
}
