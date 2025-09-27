namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class WorklogDto
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("self")]
    public string Self { get; set; }

    [JsonPropertyName("author")]
    public AuthorDto Author { get; set; }

    [JsonPropertyName("comment")]
    public CommentDto Comment { get; set; }

    [JsonPropertyName("started")]
    public string Started { get; set; }    

    [JsonPropertyName("timeSpentSeconds")]
    public int TimeSpentSeconds { get; set; }

    [JsonPropertyName("issueId")]
    public string IssueId { get; set; }
}
