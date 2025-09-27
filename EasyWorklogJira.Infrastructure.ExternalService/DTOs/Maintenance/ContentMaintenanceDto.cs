namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs.Maintenance;

public class ContentMaintenanceDto
{
    [JsonPropertyName("content")]
    public IEnumerable<InnerContentMaintenanceDto> Content { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; } = "paragraph";
}
