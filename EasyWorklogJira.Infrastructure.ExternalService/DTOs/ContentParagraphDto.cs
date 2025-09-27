namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class ContentParagraphDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
}
