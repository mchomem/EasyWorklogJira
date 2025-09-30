namespace EasyWorklogJira.Core.Application.Interfaces;

public interface IJiraService
{
    public Task<IEnumerable<JiraIssueDto>> GetIssuesWithWorklogsByDateTimeAsync(DateTimeOffset selectedDateTimeFilter);
    public Task<IEnumerable<JiraIssueDto>> GetIssuesActiveProjectsAsync();
    public Task<IEnumerable<WorklogDto>> GetIssueWorklogsAsync(string issueKey, DateTimeOffset dateTime, string userEmailAddress);
    public Task<WorklogDto> GetWorklogByIdAsync(string issueKey, string worklogId);
    public Task AddWorklogAsync(string issueKey, WorklogMaintenanceDto worklogAddDto);
    public Task UpdateWorklogAsync(string issueKey, string worklogId, WorklogMaintenanceDto worklogAddDto);
    public Task DeleteWorklogAsync(string issueKey, string worklogId);
    public Task<UserDto> GetCurrentUserAsync();
}
