namespace EasyWorklogJira.Core.Application.Interfaces;

public interface IJiraApiClient
{
    public Task<IEnumerable<JiraIssueDto>> GetIssuesWithWorklogsByDateTimeAsync(DateTimeOffset selectedDateTimeFilter);
    public Task<IEnumerable<JiraIssueDto>> GetIssuesActiveProjectsAsync();
    public Task<IEnumerable<WorklogDto>> GetIssueWorklogsAsync(string issueKey, DateTimeOffset dateTime, string userEmailAddress);
    public Task<WorklogDto> GetWorklogByIdAsync(string issueKey, string worklogId);
    public Task AddWorklogAsync(string issueKey, WorklogAddDto worklogAddDto);
    public Task UpdateWorklogAsync(string issueKey, string worklogId, WorklogAddDto worklogAddDto);
    public Task DeleteWorklogAsync(string issueKey, string worklogId);
}
