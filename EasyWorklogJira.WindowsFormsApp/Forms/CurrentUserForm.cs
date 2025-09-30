namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class CurrentUserForm : MdiChieldFormBase
{
    private readonly IJiraService _jiraService;

    public CurrentUserForm(IJiraService jiraService)
    {
        _jiraService = jiraService;

        InitializeComponent();
    }

    private async void CurrentUserForm_Load(object sender, EventArgs e)
    {
        var user = await _jiraService.GetCurrentUserAsync();

        pictureBoxUserAvatar.Load(user.AvatarUrls.Size48x48);
        labelDisplayName.Text = $"Nome: {user.DisplayName}";
        labelAccountId.Text = $"ID: {user.AccountId}";
    }
}
