namespace EasyWorklogJira.Core.Application.DTOs;

public class JiraIssueDto
{
    public string Key { get; set; }
    public string Id { get; set; }
    public FieldsDto Fields { get; set; }
    public string DisplayIssueText => $"{Key} - {Fields?.Summary}";
}
