namespace EasyWorklogJira.Core.Application.DTOs.Add;

public class WorklogAddDto
{
    public CommentAddDto Comment { get; set; }
    public string Started { get; set; }
    public long TimeSpentSeconds { get; set; }
}
