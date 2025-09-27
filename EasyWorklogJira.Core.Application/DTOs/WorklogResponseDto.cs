namespace EasyWorklogJira.Core.Application.DTOs;

public class WorklogResponseDto
{
    public IEnumerable<WorklogDto> Worklogs { get; set; } = Array.Empty<WorklogDto>();
    public int Total { get; set; }
}
