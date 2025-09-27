namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class SearchResponseDto
{
    [JsonPropertyName("issues")]
    public IEnumerable<JiraIssueDto> Issues { get; set; }
}
