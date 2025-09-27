namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs.Add;

public class InnerContentAddDto
{
    [JsonPropertyName("text")]
    public string Text { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; } = "text";
}
