namespace EasyWorklogJira.Core.Application.DTOs.Add;

public class CommentAddDto
{
    public IEnumerable<ContentAddDto> Content { get; set; }
    public string Type { get; set; } = "doc";
    public int Version { get; set; } = 1;
}
