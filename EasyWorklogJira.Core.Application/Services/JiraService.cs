namespace EasyWorklogJira.Core.Application.Services;

public class JiraService : IJiraService
{
    private readonly IJiraApiClient _jiraApiClient;

    public JiraService(IJiraApiClient jiraApiClient)
    {
        _jiraApiClient = jiraApiClient;
    }

    public async Task<IEnumerable<JiraIssueDto>> GetIssuesWithWorklogsByDateTimeAsync(DateTimeOffset selectedDateTimeFilter)
    {
        var issues = await _jiraApiClient.GetIssuesWithWorklogsByDateTimeAsync(selectedDateTimeFilter);
        return issues;
    }

    public async Task<IEnumerable<JiraIssueDto>> GetIssuesActiveProjectsAsync()
    {
        var issues = await _jiraApiClient.GetIssuesActiveProjectsAsync();
        return issues;
    }

    public async Task<IEnumerable<WorklogDto>> GetIssueWorklogsAsync(string issueKey, DateTimeOffset dateTime, string userEmailAddress)
    {
        var worklogs = await _jiraApiClient.GetIssueWorklogsAsync(issueKey, dateTime, userEmailAddress);
        return worklogs;
    }

    public async Task<IEnumerable<WorklogDto>> GetIssueWorklogsAsync(IEnumerable<JiraIssueDto> issues, DateTimeOffset dateTime, string userEmailAddress)
    {
        var listWorkLogs = new List<WorklogDto>();

        foreach (var issue in issues)
        {
            var worklogs = await _jiraApiClient.GetIssueWorklogsAsync(issue.Key, dateTime, userEmailAddress);

            if (worklogs.Any())
            {
                foreach (var w in worklogs)
                {
                    // Both "IssueKey" and "IssueSummary" fields, dont exists on WorklogDto returned by Jira API, so we need to set it manually.
                    w.IssueKey = issue.Key;
                    w.IssueSummary = issue.Fields.Summary;
                    listWorkLogs.Add(w);
                }
            }
        }

        listWorkLogs = listWorkLogs
            .OrderBy(w => w.Started)
            .ToList();

        return listWorkLogs;
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

    public async Task<JiraUserDto> GetCurrentUserAsync()
    {
        var user = await _jiraApiClient.GetCurrentUserAsync();
        return user;
    }

    public async Task<bool> IsJiraApiOnlineAsync()
    {
        var isConnected = await _jiraApiClient.IsJiraApiOnlineAsync();
        return isConnected;
    }
}
