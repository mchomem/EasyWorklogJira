namespace EasyWorklogJira.Infrastructure.ExternalService.ProfileMappings;

public static class ProfileMapping
{
    public static void RegisterMappings(TypeAdapterConfig config)
    {
        #region Mapping DTOs for data query

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
        config.NewConfig<InfraDto.JiraUserDto, AppDto.JiraUserDto>().TwoWays();

        #endregion

        #region Mapping DTOs for data maintenance (insertion/update)

        config.NewConfig<InfraDto.Maintenance.WorklogMaintenanceDto, AppDto.Maintenance.WorklogMaintenanceDto>().TwoWays();
        config.NewConfig<InfraDto.Maintenance.CommentMaintenanceDto, AppDto.Maintenance.CommentMaintenanceDto>().TwoWays();
        config.NewConfig<InfraDto.Maintenance.ContentMaintenanceDto, AppDto.Maintenance.ContentMaintenanceDto>().TwoWays();
        config.NewConfig<InfraDto.Maintenance.InnerContentMaintenanceDto, AppDto.Maintenance.InnerContentMaintenanceDto>().TwoWays();

        #endregion
    }
}
