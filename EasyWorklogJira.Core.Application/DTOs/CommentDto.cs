namespace EasyWorklogJira.Core.Application.DTOs;

public class CommentDto
{
    public string Type { get; set; }
    public int Version { get; set; }
    public IEnumerable<ContentItemDto> Content { get; set; }
}
