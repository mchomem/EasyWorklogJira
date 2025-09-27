namespace EasyWorklogJira.Core.Application.DTOs;

public class CommentDto
{
    public string Type { get; set; } = string.Empty;
    public int Version { get; set; }
    public IEnumerable<ContentItemDto> Content { get; set; } = Array.Empty<ContentItemDto>();
}
