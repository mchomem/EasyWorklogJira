namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private Dictionary<Type, Form> _openForms = new Dictionary<Type, Form>();

    public MainForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
        this.Focus();
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
}
