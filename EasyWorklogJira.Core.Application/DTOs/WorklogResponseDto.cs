namespace EasyWorklogJira.Core.Application.DTOs;

public class WorklogResponseDto
{
    public IEnumerable<WorklogDto> Worklogs { get; set; }
    public int Total { get; set; }
}
