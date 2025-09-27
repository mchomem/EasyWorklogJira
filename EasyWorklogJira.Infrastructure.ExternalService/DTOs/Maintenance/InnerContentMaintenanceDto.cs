namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs.Maintenance;

public class InnerContentMaintenanceDto
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; } = "text";
}
