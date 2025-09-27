namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class ContentItemDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("content")]
    public IEnumerable<NestedContentDto> Content { get; set; }
}
