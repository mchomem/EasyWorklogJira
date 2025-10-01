namespace EasyWorklogJira.WindowsFormsApp.Forms;

public partial class CurrentUserForm : MdiChieldFormBase
{
    private readonly IJiraService _jiraService;

    // Loader components
    private Panel loaderPanel;
    private Label loaderLabel;
    private PictureBox loaderGif;

    public CurrentUserForm(IJiraService jiraService)
    {
        _jiraService = jiraService;

        InitializeComponent();
        InitializeLoader();
    }

    private async void CurrentUserForm_Load(object sender, EventArgs e)
    {
        try
        {
            ShowLoader("Carregando dados do usuário...");

            var user = await _jiraService.GetCurrentUserAsync();

            pictureBoxUserAvatar.Load(user.AvatarUrls.Size48x48);
            labelDisplayName.Text = user.DisplayName;
            labelAccountId.Text = $"ID: {user.AccountId}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar os dados do usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            HideLoader();
        }
    }

    #region Loader methods

    private void InitializeLoader()
    {
        // Crie o painel do loader
        loaderPanel = new Panel
        {
            BackColor = Color.FromArgb(200, 255, 255, 255),
            Dock = DockStyle.Fill,
            Visible = false
        };

        // Crie o PictureBox para o GIF - adaptado para o tamanho menor do formulário
        loaderGif = new PictureBox
        {
            Size = new Size(60, 60), // Menor que o WorklogMaintenanceForm (era 80x80)
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        try
        {
            // Use o nome correto do recurso conforme definido no .resx
            loaderGif.Image = EasyWorklogJira.WindowsFormsApp.Resource.Rolling1x_1_0s_200px_200px;
        }
        catch (Exception ex)
        {
            // Em caso de erro, crie um loader alternativo simples
            Console.WriteLine($"Erro ao carregar o GIF: {ex.Message}");
            loaderGif.BackColor = Color.LightGray;
            loaderGif.BorderStyle = BorderStyle.FixedSingle;
        }

        // Crie o label com a mensagem de carregamento - adaptado para o tamanho menor
        loaderLabel = new Label
        {
            Text = "Carregando dados do usuário...",
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10, FontStyle.Bold), // Fonte um pouco menor
            Height = 25,
            ForeColor = Color.DarkBlue
        };

        loaderPanel.Controls.Add(loaderGif);
        loaderPanel.Controls.Add(loaderLabel);

        // Adicione o painel ao formulário
        this.Controls.Add(loaderPanel);

        // Traga o loader para frente dos outros controles
        loaderPanel.BringToFront();
    }

    private void ShowLoader(string message = "Carregando dados do usuário...")
    {
        // Atualize a mensagem do loader
        loaderLabel.Text = message;

        // Posicione o GIF no centro do formulário - adaptado para o tamanho menor
        loaderGif.Location = new Point(
            (this.ClientSize.Width - loaderGif.Width) / 2,
            (this.ClientSize.Height - loaderGif.Height) / 2 - 15
        );

        // Posicione o label abaixo do GIF
        loaderLabel.Size = new Size(this.ClientSize.Width, 25);
        loaderLabel.Location = new Point(
            0,
            loaderGif.Bottom + 8
        );

        // Desabilite todos os controles do formulário exceto o loader
        SetControlsEnabled(false);

        // Mostre o loader
        loaderPanel.Visible = true;
        Application.DoEvents(); // Force a atualização da UI
    }

    private void HideLoader()
    {
        // Esconda o loader
        loaderPanel.Visible = false;

        // Reabilite todos os controles do formulário
        SetControlsEnabled(true);
    }

    private void SetControlsEnabled(bool enabled)
    {
        // Disable/Enable all controls except the loader panel
        foreach (Control control in this.Controls)
        {
            if (control != loaderPanel)
            {
                control.Enabled = enabled;
            }
        }
    }

    #endregion
}
