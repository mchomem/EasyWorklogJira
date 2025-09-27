namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class WorklogResponseDto
{
    [JsonPropertyName("worklogs")]
    public IEnumerable<WorklogDto> Worklogs { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }
}
