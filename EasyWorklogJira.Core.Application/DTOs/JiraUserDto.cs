namespace EasyWorklogJira.Core.Application.DTOs;

public class JiraUserDto
{
    public string AccountId { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public AvatarUrlsDto AvatarUrls { get; set; } = new();
}
