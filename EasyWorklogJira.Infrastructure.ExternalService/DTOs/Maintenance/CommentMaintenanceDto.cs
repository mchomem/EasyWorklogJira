namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs.Maintenance;

public class CommentMaintenanceDto
{
    [JsonPropertyName("content")]
    public IEnumerable<ContentMaintenanceDto> Content { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = "doc";

    [JsonPropertyName("version")]
    public int Version { get; set; } = 1;
}
