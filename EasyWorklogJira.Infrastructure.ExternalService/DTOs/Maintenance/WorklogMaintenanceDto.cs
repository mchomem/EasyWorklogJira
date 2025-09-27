namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs.Maintenance;

public class WorklogMaintenanceDto
{
    [JsonPropertyName("comment")]
    public CommentMaintenanceDto Comment { get; set; }
    
    [JsonPropertyName("started")]
    public string Started { get; set; }
    
    [JsonPropertyName("timeSpentSeconds")]
    public long TimeSpentSeconds { get; set; }
}
