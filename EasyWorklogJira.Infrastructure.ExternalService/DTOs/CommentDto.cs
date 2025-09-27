namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class CommentDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("version")]
    public int Version { get; set; }

    [JsonPropertyName("content")]
    public IEnumerable<ContentItemDto> Content { get; set; }
}
