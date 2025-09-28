namespace EasyWorklogJira.Test.Unit;

public class WorklogValidationData
{
    public string SelectedIssue { get; set; } = string.Empty;
    public string StartTime { get; set; } = string.Empty;
    public string TimeSpent { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class ValidationResult
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; set; } = new();
}

public static class WorklogValidator
{
    public static ValidationResult IsValid(WorklogValidationData data)
    {
        var result = new ValidationResult { IsValid = true };

        if (string.IsNullOrEmpty(data.SelectedIssue))
            result.Errors.Add("Issue é obrigatória");

        if (string.IsNullOrEmpty(data.StartTime))
            result.Errors.Add("Horário de início é obrigatório");

        if (string.IsNullOrEmpty(data.TimeSpent))
            result.Errors.Add("Tempo gasto é obrigatório");

        if (string.IsNullOrEmpty(data.Description))
            result.Errors.Add("Descrição é obrigatória");

        result.IsValid = result.Errors.Count == 0;
        return result;
    }
}

public static class TimeValidator
{
    public static bool IsValidTime(string time)
    {
        return TimeSpan.TryParse(time, out _);
    }
}
