namespace EasyWorklogJira.Core.Application.DTOs;

public class NestedContentDto
{
    public string Type { get; set; }
    public IEnumerable<TextContentDto> Content { get; set; }
    public string Text { get; set; }
}
