namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class TextContentDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; } // paragraph

    [JsonPropertyName("content")]
    public IEnumerable<ContentParagraphDto> Content { get; set; }
}
