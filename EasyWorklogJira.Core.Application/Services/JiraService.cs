namespace EasyWorklogJira.Core.Application.Services;

public class JiraService : IJiraService
{
    private readonly IJiraApiClient _jiraApiClient;

    public JiraService(IJiraApiClient jiraApiClient)
    {
        _jiraApiClient = jiraApiClient;
    }

    public Task<IEnumerable<JiraIssueDto>> GetIssuesWithWorklogsByDateTimeAsync(DateTimeOffset selectedDateTimeFilter)
    {
        var issues = _jiraApiClient.GetIssuesWithWorklogsByDateTimeAsync(selectedDateTimeFilter);
        return issues;
    }

    public Task<IEnumerable<JiraIssueDto>> GetIssuesActiveProjectsAsync()
    {
        var issues = _jiraApiClient.GetIssuesActiveProjectsAsync();
        return issues;
    }

    public Task<IEnumerable<WorklogDto>> GetIssueWorklogsAsync(string issueKey, DateTimeOffset dateTime, string userEmailAddress)
    {
        var worklogs = _jiraApiClient.GetIssueWorklogsAsync(issueKey, dateTime, userEmailAddress);
        return worklogs;
    }

    public async Task<WorklogDto> GetWorklogByIdAsync(string issueKey, string worklogId)
    {
        var worklog = await _jiraApiClient.GetWorklogByIdAsync(issueKey, worklogId);
        return worklog;
    }

    public async Task AddWorklogAsync(string issueKey, WorklogMaintenanceDto worklogAddDto)
    {
        await _jiraApiClient.AddWorklogAsync(issueKey, worklogAddDto);
    }

    public async Task UpdateWorklogAsync(string issueKey, string worklogId, WorklogMaintenanceDto worklogAddDto)
    {
        await _jiraApiClient.UpdateWorklogAsync(issueKey, worklogId, worklogAddDto);
    }

    public async Task DeleteWorklogAsync(string issueKey, string worklogId)
    {
        await _jiraApiClient.DeleteWorklogAsync(issueKey, worklogId);
    }
}
