namespace EasyWorklogJira.Core.Application.DTOs;

public class JiraIssueDto
{
    public string Key { get; set; } = string.Empty;
    public string Id { get; set; } = string.Empty;
    public FieldsDto Fields { get; set; } = new FieldsDto();
    public string DisplayIssueText => $"{Key} - {Fields?.Summary}";
}
