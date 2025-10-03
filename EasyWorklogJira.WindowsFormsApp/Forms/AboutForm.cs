namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class AboutForm : MdiChieldFormBase
{
    private readonly ILocalizationService _localizationService;
    private readonly IConfiguration _configuration;

    public AboutForm(ILocalizationService localizationService, IConfiguration configuration)
    {
        _localizationService = localizationService;
        _configuration = configuration;
        InitializeComponent();
        GetTranslate();
    }

    private void GetTranslate()
    {
        var language = _configuration.GetValue<string>("Localization:language");
        var aboutForm = _localizationService.GetForm<AboutFormLocalization>(language);
        this.Text = aboutForm.Title;
        labelTextAbout.Text = aboutForm.Control.LabelTextAbout;
    }
}
