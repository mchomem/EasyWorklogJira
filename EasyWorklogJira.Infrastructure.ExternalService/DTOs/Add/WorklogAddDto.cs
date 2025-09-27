namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs.Add;

public class WorklogAddDto
{
    [JsonPropertyName("comment")]
    public CommentAddDto Comment { get; set; }
    
    [JsonPropertyName("started")]
    public string Started { get; set; }
    
    [JsonPropertyName("timeSpentSeconds")]
    public long TimeSpentSeconds { get; set; }
}
