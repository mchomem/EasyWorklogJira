namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILocalizationService _localizationService;
    private readonly IJiraService _jiraService;
    private readonly INetworkService _networkService;
    private readonly IConfiguration _configuration;
    private readonly System.Windows.Forms.Timer _appTimer;
    private Dictionary<Type, Form> _openForms = new Dictionary<Type, Form>();

    public MainForm(IServiceProvider serviceProvider,
        ILocalizationService localizationService,
        IJiraService jiraService,
        INetworkService networkService,
        IConfiguration configuration)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;
        _localizationService = localizationService;
        _jiraService = jiraService;
        _networkService = networkService;
        _configuration = configuration;

        _appTimer = new System.Windows.Forms.Timer()
        {
            Interval = 1000 * 60 * 5 // 5 min.
        };

        _appTimer.Tick += async (s, e) => await CheckInternetConnection();

        GetTranslate();
        Focus();
    }

    private void GetTranslate()
    {
        var language = _configuration.GetValue<string>("Localization:language");

        var mainForm = _localizationService.GetForm<Infrastructure.Localization.Models.MainFormLocalization>(language);
        systemToolStripMenuItem.Text = mainForm.MainMenu.SystemMenu.Text;
        configurationToolStripMenuItem.Text = mainForm.MainMenu.SystemMenu.Chieldren.ConfigurationMenuItem;
        currentUserToolStripMenuItem.Text = mainForm.MainMenu.SystemMenu.Chieldren.CurrentUserMenuItem;
        exitToolStripMenuItem.Text = mainForm.MainMenu.SystemMenu.Chieldren.ExitMenuItem;

        resourcesToolStripMenuItem.Text = mainForm.MainMenu.ResourcesMenu.Text;
        worklogToolStripMenuItem.Text = mainForm.MainMenu.ResourcesMenu.Chieldren.WorklogMenuItem;

        helpToolStripMenuItem.Text = mainForm.MainMenu.HelpMenu.Text;
        aboutToolStripMenuItem.Text = mainForm.MainMenu.HelpMenu.Chieldren.AboutMenuItem;
    }

    private void setupToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowSingleInstanceForm<ConfigurationForm>();
    }

    private void userApplicationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowSingleInstanceForm<CurrentUserForm>();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Exit();
    }

    private void queryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowSingleInstanceForm<WorklogListingForm>();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ShowSingleInstanceForm<AboutForm>();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        await CheckInternetConnection();

        ShowSingleInstanceForm<WorklogListingForm>();

        _appTimer.Start();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _appTimer.Stop();
        _appTimer.Dispose();
    }

    public void ShowSingleInstanceForm<T>() where T : Form
    {
        // Verifica se já existe uma instância aberta do formulário
        if (_openForms.TryGetValue(typeof(T), out Form existingForm) && !existingForm.IsDisposed)
        {
            // Se o formulário já estiver aberto, traz para frente
            if (existingForm.WindowState == FormWindowState.Minimized)
                existingForm.WindowState = FormWindowState.Normal;

            existingForm.Focus();
            return;
        }

        // Cria uma nova instância do formulário
        var newForm = _serviceProvider.GetRequiredService<T>();
        newForm.MdiParent = this;

        // Adiciona ao dicionário de formulários abertos
        _openForms[typeof(T)] = newForm;

        // Remove do dicionário quando o formulário for fechado
        newForm.FormClosed += (s, args) =>
        {
            _openForms.Remove(typeof(T));
            newForm.Dispose();
        };

        newForm.Show();
    }

    private static void Exit()
    {
        Environment.Exit(0);
    }

    private async Task CheckInternetConnection()
    {
        toolStripStatusLabelWebConnectionValue.Text = "verificando conexões de rede ...";
        toolStripStatusLabelWebConnectionValue.BackColor = Color.Transparent;
        toolStripStatusLabelWebConnectionValue.ForeColor = Color.Black;

        var isConnected = await _networkService.IsInternetAvailableAsync();

        if (isConnected)
        {
            toolStripStatusLabelWebConnectionValue.Text = "App ON LINE";
            toolStripStatusLabelWebConnectionValue.BackColor = Color.Green;
            toolStripStatusLabelWebConnectionValue.ForeColor = Color.White;

            await CheckJiraConnection();
        }
        else
        {
            toolStripStatusLabelWebConnectionValue.Text = "App OFF LINE";
            toolStripStatusLabelWebConnectionValue.BackColor = Color.Red;
            toolStripStatusLabelWebConnectionValue.ForeColor = Color.White;
        }
    }

    private async Task CheckJiraConnection()
    {
        var isConnected = await _jiraService.IsJiraApiOnlineAsync();

        if (isConnected)
        {
            toolStripStatusLabelWebConnectionValue.Text = "Jira ON LINE";
            toolStripStatusLabelWebConnectionValue.BackColor = Color.Green;
            toolStripStatusLabelWebConnectionValue.ForeColor = Color.White;
        }
        else
        {
            toolStripStatusLabelWebConnectionValue.Text = "Jira OFF LINE";
            toolStripStatusLabelWebConnectionValue.BackColor = Color.Red;
            toolStripStatusLabelWebConnectionValue.ForeColor = Color.White;
        }
    }
}
