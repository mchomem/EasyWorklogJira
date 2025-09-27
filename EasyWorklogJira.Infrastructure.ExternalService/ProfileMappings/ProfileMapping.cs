namespace EasyWorklogJira.Infrastructure.ExternalService.ProfileMappings;

public static class ProfileMapping
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        config.NewConfig<InfraDto.AuthorDto, AppDto.AuthorDto>().TwoWays();
        config.NewConfig<InfraDto.CommentDto, AppDto.CommentDto>().TwoWays();
        config.NewConfig<InfraDto.ContentItemDto, AppDto.ContentItemDto>().TwoWays();
        config.NewConfig<InfraDto.ContentParagraphDto, AppDto.ContentParagraphDto>().TwoWays();
        config.NewConfig<InfraDto.FieldsDto, AppDto.FieldsDto>().TwoWays();
        config.NewConfig<InfraDto.JiraIssueDto, AppDto.JiraIssueDto>().TwoWays();
        config.NewConfig<InfraDto.NestedContentDto, AppDto.NestedContentDto>().TwoWays();        
        config.NewConfig<InfraDto.SearchResponseDto, AppDto.SearchResponseDto>().TwoWays();        
        config.NewConfig<InfraDto.TextContentDto, AppDto.TextContentDto>().TwoWays();
        config.NewConfig<InfraDto.WorklogDto, AppDto.WorklogDto>().TwoWays();
        config.NewConfig<InfraDto.WorklogResponseDto, AppDto.WorklogResponseDto>().TwoWays();

        config.NewConfig<InfraDto.Add.WorklogAddDto, AppDto.Add.WorklogAddDto>().TwoWays();
        config.NewConfig<InfraDto.Add.CommentAddDto, AppDto.Add.CommentAddDto>().TwoWays();
        config.NewConfig<InfraDto.Add.ContentAddDto, AppDto.Add.ContentAddDto>().TwoWays();
        config.NewConfig<InfraDto.Add.InnerContentAddDto, AppDto.Add.InnerContentAddDto>().TwoWays();
    }
}
