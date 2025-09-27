namespace EasyWorklogJira.Core.Application.DTOs;

public class TextContentDto
{
    public string Type { get; set; } // paragraph
    public IEnumerable<ContentParagraphDto> Content { get; set; } = Enumerable.Empty<ContentParagraphDto>();
}
