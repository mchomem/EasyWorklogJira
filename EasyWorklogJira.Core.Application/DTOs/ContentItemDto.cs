namespace EasyWorklogJira.Core.Application.DTOs;

public class ContentItemDto
{
    public string Type { get; set; } = string.Empty;

    public IEnumerable<NestedContentDto> Content { get; set; } = Array.Empty<NestedContentDto>();
}
