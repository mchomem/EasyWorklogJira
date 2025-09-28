namespace EasyWorklogJira.Test.Integration;

public class JiraServiceIntegrationTests : IClassFixture<IntegrationTestFixture>
{
    private readonly IJiraService _jiraService;
    private readonly IConfiguration _configuration;

    public JiraServiceIntegrationTests(IntegrationTestFixture fixture)
    {
        _jiraService = fixture.ServiceProvider.GetService<IJiraService>();
        _configuration = fixture.ServiceProvider.GetService<IConfiguration>();
    }

    [Fact]
    public async Task GetIssuesActiveProjectsAsync_WhenCalled_ReturnsIssues()
    {
        // Act
        var issues = await _jiraService.GetIssuesActiveProjectsAsync();

        // Assert
        Assert.NotNull(issues);
        Assert.True(issues.Any()); // Assume que há pelo menos uma issue ativa
    }

    [Fact]
    public async Task AddWorklogAsync_WhenValidData_CreatesWorklogSuccessfully()
    {
        // Arrange
        var testIssueKey = "AC-1"; // Use uma issue real do seu ambiente de teste
        var worklog = new WorklogMaintenanceDto
        {
            Comment = new CommentMaintenanceDto
            {
                Content = new List<ContentMaintenanceDto>
                {
                    new ContentMaintenanceDto
                    {
                        Content = new List<InnerContentMaintenanceDto>
                        {
                            new InnerContentMaintenanceDto { Text = "Reunião (teste de integração)" }
                        }
                    }
                }
            },
            Started = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff-0300"),
            TimeSpentSeconds = 3600 // 1 hora
        };

        // Act & Assert (Pode falhar se a issue não existir no ambiente de teste)
        await _jiraService.AddWorklogAsync(testIssueKey, worklog);
    }

    [Fact]
    public async Task GetWorklogByIdAsync_WhenWorklogExists_ReturnsWorklog()
    {
        // Arrange
        var testIssueKey = "AC-1";
        var testWorklogId = "133654"; // Use um worklog ID real do seu ambiente

        // Act
        var worklog = await _jiraService.GetWorklogByIdAsync(testIssueKey, testWorklogId);

        // Assert
        Assert.NotNull(worklog);
        Assert.Equal(testWorklogId, worklog.Id);
    }
}
