namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs.Add;

public class ContentAddDto
{
    [JsonPropertyName("content")]
    public IEnumerable<InnerContentAddDto> Content { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; } = "paragraph";
}
