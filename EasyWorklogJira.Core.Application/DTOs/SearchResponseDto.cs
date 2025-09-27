namespace EasyWorklogJira.Core.Application.DTOs;

public class SearchResponseDto
{
    public IEnumerable<JiraIssueDto> Issues { get; set; }
}
