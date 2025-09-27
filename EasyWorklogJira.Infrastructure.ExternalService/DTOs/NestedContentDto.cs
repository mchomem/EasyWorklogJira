namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class NestedContentDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("content")]
    public IEnumerable<TextContentDto> Content { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }
}
