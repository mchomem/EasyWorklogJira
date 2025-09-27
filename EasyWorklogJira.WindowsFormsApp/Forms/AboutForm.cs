namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class AboutForm : MdiChieldFormBase
{
    public AboutForm()
    {
        InitializeComponent();
    }

    private void AboutForm_Load(object sender, EventArgs e)
    {
        labelTextAbout.Text = "Easy Worklog Jira\n" +
            "\n" +
            "Aplicativo desktop projetado para simplificar drasticamente o registro de horas\n" +
            "de trabalho no sistema Jira.\n" +
            "\n" +
            "Versão 1.0.0\n\n" +
            "Desenvolvido por Misael C. Homem\n" +
            "\n" +
            "2025";
    }
}
