namespace EasyWorklogJira.Core.Application.DTOs.Maintenance;

public class CommentMaintenanceDto
{
    public IEnumerable<ContentMaintenanceDto> Content { get; set; } = new List<ContentMaintenanceDto>();
    public string Type { get; set; } = "doc";
    public int Version { get; set; } = 1;
}
