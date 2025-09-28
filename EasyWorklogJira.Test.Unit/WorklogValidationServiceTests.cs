namespace EasyWorklogJira.Test.Unit;

public class WorklogValidationServiceTests
{
    [Fact]
    public void ValidateWorklogData_WhenAllFieldsAreValid_ReturnsTrue()
    {
        // Arrange
        var worklogData = new WorklogValidationData
        {
            SelectedIssue = "TEST-123",
            StartTime = "09:00",
            TimeSpent = "02:30",
            Description = "Implementação de testes"
        };

        // Act
        var result = WorklogValidator.IsValid(worklogData);

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    [Theory]
    [InlineData("", "09:00", "02:30", "Descrição", "Issue é obrigatória")]
    [InlineData("TEST-123", "", "02:30", "Descrição", "Horário de início é obrigatório")]
    [InlineData("TEST-123", "09:00", "", "Descrição", "Tempo gasto é obrigatório")]
    [InlineData("TEST-123", "09:00", "02:30", "", "Descrição é obrigatória")]
    public void ValidateWorklogData_WhenRequiredFieldsAreMissing_ReturnsFalse(
        string issue, string startTime, string timeSpent, string description, string expectedError)
    {
        // Arrange
        var worklogData = new WorklogValidationData
        {
            SelectedIssue = issue,
            StartTime = startTime,
            TimeSpent = timeSpent,
            Description = description
        };

        // Act
        var result = WorklogValidator.IsValid(worklogData);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(expectedError, result.Errors);
    }

    [Theory]
    [InlineData("25:00", false)] // Hora inválida
    [InlineData("12:60", false)] // Minuto inválido
    [InlineData("09:30", true)]  // Hora válida
    public void ValidateTimeFormat_ShouldValidateCorrectly(string time, bool expectedValid)
    {
        // Act
        var isValid = TimeValidator.IsValidTime(time);

        // Assert
        Assert.Equal(expectedValid, isValid);
    }
}
