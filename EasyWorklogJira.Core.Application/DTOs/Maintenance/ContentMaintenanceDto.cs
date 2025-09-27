namespace EasyWorklogJira.Core.Application.DTOs.Maintenance;

public class ContentMaintenanceDto
{
    public IEnumerable<InnerContentMaintenanceDto> Content { get; set; } = new List<InnerContentMaintenanceDto>();
    public string Type { get; set; } = "paragraph";
}
