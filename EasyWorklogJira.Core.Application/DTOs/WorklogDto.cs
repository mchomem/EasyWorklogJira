namespace EasyWorklogJira.Core.Application.DTOs;

public class WorklogDto
{
    public string Id { get; set; }
    public string Self { get; set; }
    public AuthorDto Author { get; set; }
    public CommentDto Comment { get; set; }
    public string Started { get; set; }
    public int TimeSpentSeconds { get; set; }
    public string IssueId { get; set; }
}
