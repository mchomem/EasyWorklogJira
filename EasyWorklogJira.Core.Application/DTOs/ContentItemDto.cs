namespace EasyWorklogJira.Core.Application.DTOs;

public class ContentItemDto
{
    public string Type { get; set; }

    public IEnumerable<NestedContentDto> Content { get; set; }
}
