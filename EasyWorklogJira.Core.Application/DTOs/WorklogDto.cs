namespace EasyWorklogJira.Core.Application.DTOs;

public class WorklogDto
{
    public string Id { get; set; } = string.Empty;
    public string Self { get; set; } = string.Empty;
    public AuthorDto Author { get; set; } = new AuthorDto();
    public CommentDto Comment { get; set; } = new CommentDto();
    public string Started { get; set; } = string.Empty;
    public int TimeSpentSeconds { get; set; }
    public string IssueId { get; set; } = string.Empty;
    public string IssueKey { get; set; } = string.Empty;
}
