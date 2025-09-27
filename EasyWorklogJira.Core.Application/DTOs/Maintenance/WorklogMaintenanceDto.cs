namespace EasyWorklogJira.Core.Application.DTOs.Maintenance;

public class WorklogMaintenanceDto
{
    public CommentMaintenanceDto Comment { get; set; } = new CommentMaintenanceDto();
    public string Started { get; set; } = string.Empty;
    public long TimeSpentSeconds { get; set; }
}
