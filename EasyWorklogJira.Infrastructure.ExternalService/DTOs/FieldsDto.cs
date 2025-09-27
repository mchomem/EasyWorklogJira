namespace EasyWorklogJira.Infrastructure.ExternalService.DTOs;

public class FieldsDto
{
    [JsonPropertyName("summary")]
    public string Summary { get; set; }
}
