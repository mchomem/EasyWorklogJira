namespace EasyWorklogJira.Core.Application.DTOs;

public class NestedContentDto
{
    public string Type { get; set; } = string.Empty;
    public IEnumerable<TextContentDto> Content { get; set; } = Array.Empty<TextContentDto>();
    public string Text { get; set; } = string.Empty;
}
