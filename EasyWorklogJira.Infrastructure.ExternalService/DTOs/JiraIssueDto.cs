namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class JiraIssueDto
{
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("fields")]
    public FieldsDto Fields { get; set; }
}
