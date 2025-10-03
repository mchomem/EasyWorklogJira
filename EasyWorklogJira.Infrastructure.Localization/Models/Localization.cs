namespace EasyWorklogJira.Infrastructure.Localization.Models;

public class AboutFormLocalization

{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("control")]
    public ControlLocalization Control { get; set; }
}

public class Chieldren
{
    [JsonPropertyName("configurationMenuItem")]
    public string ConfigurationMenuItem { get; set; }

    [JsonPropertyName("currentUserMenuItem")]
    public string CurrentUserMenuItem { get; set; }

    [JsonPropertyName("exitMenuItem")]
    public string ExitMenuItem { get; set; }

    [JsonPropertyName("worklogMenuItem")]
    public string WorklogMenuItem { get; set; }

    [JsonPropertyName("aboutMenuItem")]
    public string AboutMenuItem { get; set; }
}

public class ConfigurationFormLocalization
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("control")]
    public ControlLocalization Control { get; set; }
}

public class ControlLocalization
{
    [JsonPropertyName("labelTextAbout")]
    public string LabelTextAbout { get; set; }

    [JsonPropertyName("labelIssue")]
    public string LabelIssue { get; set; }

    [JsonPropertyName("labelDate")]
    public string LabelDate { get; set; }

    [JsonPropertyName("labelStartTime")]
    public string LabelStartTime { get; set; }

    [JsonPropertyName("labelEndTime")]
    public string LabelEndTime { get; set; }

    [JsonPropertyName("labelTimeSpent")]
    public string LabelTimeSpent { get; set; }

    [JsonPropertyName("labelWorklogDescription")]
    public string LabelWorklogDescription { get; set; }

    [JsonPropertyName("buttonSave")]
    public string ButtonSave { get; set; }

    [JsonPropertyName("tabPageDefault")]
    public string TabPageDefault { get; set; }

    [JsonPropertyName("groupBoxWebSite")]
    public string GroupBoxWebSite { get; set; }

    [JsonPropertyName("labelUrlBase")]
    public string LabelUrlBase { get; set; }

    [JsonPropertyName("groupBoxJiraAccessCredentials")]
    public string GroupBoxJiraAccessCredentials { get; set; }

    [JsonPropertyName("labelEmail")]
    public string LabelEmail { get; set; }

    [JsonPropertyName("labelInformationToken")]
    public string LabelInformationToken { get; set; }

    [JsonPropertyName("labelToken")]
    public string LabelToken { get; set; }

    [JsonPropertyName("groupBoxDailyMeetingSchedule")]
    public string GroupBoxDailyMeetingSchedule { get; set; }

    [JsonPropertyName("labelWarningRule")]
    public string LabelWarningRule { get; set; }

    [JsonPropertyName("tabPageJiraQueries")]
    public string TabPageJiraQueries { get; set; }

    [JsonPropertyName("labelCommonAndActiveSprintIssues")]
    public string LabelCommonAndActiveSprintIssues { get; set; }

    [JsonPropertyName("labelNote")]
    public string LabelNote { get; set; }

    [JsonPropertyName("buttonClose")]
    public string ButtonClose { get; set; }

    [JsonPropertyName("groupBoxUserData")]
    public string GroupBoxUserData { get; set; }

    [JsonPropertyName("labelName")]
    public string LabelName { get; set; }

    [JsonPropertyName("labelResume")]
    public string LabelResume { get; set; }

    [JsonPropertyName("columnIssueKey")]
    public string ColumnIssueKey { get; set; }

    [JsonPropertyName("columnStartTime")]
    public string ColumnStartTime { get; set; }

    [JsonPropertyName("columnEndTime")]
    public string ColumnEndTime { get; set; }

    [JsonPropertyName("columnUpdate")]
    public string ColumnUpdate { get; set; }

    [JsonPropertyName("columnDelete")]
    public string ColumnDelete { get; set; }

    [JsonPropertyName("labelTotalHoursDay")]
    public string LabelTotalHoursDay { get; set; }

    [JsonPropertyName("buttonNew")]
    public string ButtonNew { get; set; }

    [JsonPropertyName("groupBoxLocalization")]
    public string GroupBoxLocalization { get; set; }

    [JsonPropertyName("labelLanguage")]
    public string LabelLanguage { get; set; }
}

public class CurrentUserFormLocalization
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("control")]
    public ControlLocalization Control { get; set; }
}

public class EnUS
{
    [JsonPropertyName("form")]
    public FormLocalization Form { get; set; }
}

public class FormLocalization
{
    [JsonPropertyName("mainForm")]
    public MainFormLocalization MainForm { get; set; }

    [JsonPropertyName("aboutForm")]
    public AboutFormLocalization AboutForm { get; set; }

    [JsonPropertyName("configurationForm")]
    public ConfigurationFormLocalization ConfigurationForm { get; set; }

    [JsonPropertyName("currentUserForm")]
    public CurrentUserFormLocalization CurrentUserForm { get; set; }

    [JsonPropertyName("worklogListingForm")]
    public WorklogListingFormLocalization WorklogListingForm { get; set; }

    [JsonPropertyName("worklogMaintenanceForm")]
    public WorklogMaintenanceFormLocalization WorklogMaintenanceForm { get; set; }
}

public class HelpMenu
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("chieldren")]
    public Chieldren Chieldren { get; set; }
}

public class MainFormLocalization
{
    [JsonPropertyName("mainMenu")]
    public MainMenu MainMenu { get; set; }
}

public class MainMenu
{
    [JsonPropertyName("systemMenu")]
    public SystemMenu SystemMenu { get; set; }

    [JsonPropertyName("resourcesMenu")]
    public ResourcesMenu ResourcesMenu { get; set; }

    [JsonPropertyName("helpMenu")]
    public HelpMenu HelpMenu { get; set; }
}

public class PtBR
{
    [JsonPropertyName("form")]
    public FormLocalization Form { get; set; }
}

public class ResourcesMenu
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("chieldren")]
    public Chieldren Chieldren { get; set; }
}

public class Root
{
    [JsonPropertyName("en_US")]
    public EnUS EnUS { get; set; }

    [JsonPropertyName("pt_BR")]
    public PtBR PtBR { get; set; }
}

public class SystemMenu
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("chieldren")]
    public Chieldren Chieldren { get; set; }
}

public class WorklogListingFormLocalization
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("control")]
    public ControlLocalization Control { get; set; }
}

public class WorklogMaintenanceFormLocalization
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("control")]
    public ControlLocalization Control { get; set; }
}
