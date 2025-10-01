// doc: https://developer.atlassian.com/cloud/jira/platform/rest/v3/api-group-issue-worklogs/#api-rest-api-3-issue-issueidorkey-worklog-get

namespace EasyWorklogJira.Infrastructure.ExternalService.Clients;

public class JiraApiClient : IJiraApiClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public JiraApiClient(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _mapper = mapper;

        var email = _configuration["JiraConnection:email"];
        var apiToken = _configuration["JiraConnection:token"];
        var authString = $"{email}:{apiToken}";
        var encodedAuthString = Convert.ToBase64String(Encoding.UTF8.GetBytes(authString));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedAuthString);
    }

    public async Task<IEnumerable<AppDto.JiraIssueDto>> GetIssuesWithWorklogsByDateTimeAsync(DateTimeOffset selectedDateTimeFilter)
    {
        // JQL para buscar issues com worklogs do usuário logados hoje.
        var jql = $"worklogDate = \"{selectedDateTimeFilter.ToString("yyyy-MM-dd")}\" AND worklogAuthor = currentUser() ORDER BY created ASC";
        var url = $"{_httpClient.BaseAddress}/rest/api/3/search/jql?jql={Uri.EscapeDataString(jql)}&fields=*all";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var searchResult = JsonSerializer.Deserialize<SearchResponseDto>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        return _mapper.Map<IEnumerable<AppDto.JiraIssueDto>>(searchResult?.Issues) ?? new List<AppDto.JiraIssueDto>();
    }

    public async Task<IEnumerable<AppDto.JiraIssueDto>> GetIssuesActiveProjectsAsync()
    {
        // JQl para buscar as issues dos projetos auxiliares, e projetos da sprint ativa e que estão atribuídas ao usuário logado.
        var jql = _configuration["JiraQueries:commonAndActiveSprintIssues"];

        if (string.IsNullOrEmpty(jql))
        {
            // Consulta padrão: buscar as issues da sprint ativa e que estão atribuídas ao usuário logado.
            jql = "sprint in openSprints() AND assignee = currentUser() ORDER BY created ASC";
        }

        var url = $"{_httpClient.BaseAddress}/rest/api/3/search/jql?jql={Uri.EscapeDataString(jql)}&fields=*all";

        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var searchResult = JsonSerializer.Deserialize<SearchResponseDto>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        return _mapper.Map<IEnumerable<AppDto.JiraIssueDto>>(searchResult?.Issues) ?? new List<AppDto.JiraIssueDto>();
    }

    public async Task<IEnumerable<AppDto.WorklogDto>> GetIssueWorklogsAsync(string issueKey, DateTimeOffset dateTime, string userEmailAddress)
    {
        var allWorklogs = new List<WorklogDto>();
        int startAt = 0;
        int maxResults = 100;
        int total = 0;

        // Converte a data inicial para timestamp Unix em milissegundos
        long startedAfterTimestamp = dateTime.ToUnixTimeMilliseconds();
        long endedTimestamp = dateTime
            .AddHours(23)
            .AddMinutes(59)
            .AddSeconds(59)
            .ToUnixTimeMilliseconds();

        do
        {
            var url = $"{_httpClient.BaseAddress}/rest/api/3/issue/{issueKey}/worklog?startAt={startAt}&maxResults={maxResults}&startedAfter={startedAfterTimestamp}&startedBefore={endedTimestamp}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var worklogsResult = JsonSerializer.Deserialize<WorklogResponseDto>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (worklogsResult?.Worklogs != null)
                allWorklogs.AddRange(worklogsResult.Worklogs);

            // Filtra pelo e-mail do usuário para distinguir os worklogs do usuário autenticado.
            allWorklogs = allWorklogs
                .Where(x => x.Author.EmailAddress == userEmailAddress) // TODO: analisar novamente a estrutura de dados para ver uma outra forma mais eficiente de filtrar os worklogs somente do usuário, não utilizando o seu e-mail como filtro.
                .ToList();

            total = worklogsResult?.Total ?? 0;
            startAt += maxResults;

        } while (startAt < total);

        return _mapper.Map<IEnumerable<AppDto.WorklogDto>>(allWorklogs);
    }

    public async Task<AppDto.WorklogDto> GetWorklogByIdAsync(string issueKey, string worklogId)
    {
        var url = $"{_httpClient.BaseAddress}/rest/api/3/issue/{issueKey}/worklog/{worklogId}";
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var worklogResult = JsonSerializer.Deserialize<WorklogDto>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        return _mapper.Map<AppDto.WorklogDto>(worklogResult!);
    }

    public async Task AddWorklogAsync(string issueKey, AppDto.Maintenance.WorklogMaintenanceDto worklogAddDto)
    {
        var url = $"{_httpClient.BaseAddress}/rest/api/3/issue/{issueKey}/worklog";
        var worklogInfraAppDto = _mapper.Map<InfraDto.Maintenance.WorklogMaintenanceDto>(worklogAddDto);
        var serializedObject = JsonSerializer.Serialize(worklogInfraAppDto);

        var content = new StringContent
        (
            serializedObject,
            Encoding.UTF8,
            "application/json"
        );

        HttpResponseMessage response = await _httpClient.PostAsync(url, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateWorklogAsync(string issueKey, string worklogId, AppDto.Maintenance.WorklogMaintenanceDto worklogAddDto)
    {
        var url = $"{_httpClient.BaseAddress}/rest/api/3/issue/{issueKey}/worklog/{worklogId}";
        var worklogInfraAppDto = _mapper.Map<InfraDto.Maintenance.WorklogMaintenanceDto>(worklogAddDto);
        var serializedObject = JsonSerializer.Serialize(worklogInfraAppDto);

        var content = new StringContent
        (
            serializedObject,
            Encoding.UTF8,
            "application/json"
        );

        HttpResponseMessage response = await _httpClient.PutAsync(url, content);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteWorklogAsync(string issueKey, string worklogId)
    {
        var url = $"{_httpClient.BaseAddress}/rest/api/3/issue/{issueKey}/worklog/{worklogId}";
        HttpResponseMessage response = await _httpClient.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
    }

    public async Task<AppDto.UserDto> GetCurrentUserAsync()
    {
        var url = $"{_httpClient.BaseAddress}/rest/api/3/myself";
        HttpResponseMessage response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var userResult = JsonSerializer.Deserialize<UserDto>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        return _mapper.Map<AppDto.UserDto>(userResult!);
    }
}
