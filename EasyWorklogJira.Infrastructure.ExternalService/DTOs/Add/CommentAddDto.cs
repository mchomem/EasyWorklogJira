namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs.Add;

public class CommentAddDto
{
    [JsonPropertyName("content")]
    public IEnumerable<ContentAddDto> Content { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = "doc";

    [JsonPropertyName("version")]
    public int Version { get; set; } = 1;
}
