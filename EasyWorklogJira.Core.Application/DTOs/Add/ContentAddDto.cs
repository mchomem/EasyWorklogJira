namespace EasyWorklogJira.Core.Application.DTOs.Add;

public class ContentAddDto
{
    public IEnumerable<InnerContentAddDto> Content { get; set; }
    public string Type { get; set; } = "paragraph";
}
