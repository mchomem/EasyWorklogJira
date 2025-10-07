using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace EasyWorklogJira.WPFApp.Views;

/// <summary>
/// Interaction logic for SettingsViewView.xaml
/// </summary>
public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private void Hyperlink_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Process.Start(new ProcessStartInfo()
        {
            FileName = "https://id.atlassian.com/manage-profile/security/api-tokens",
            UseShellExecute = true
        });
    }

    private void buttonSave_Click(object sender, System.Windows.RoutedEventArgs e)
    {


        MessageBox.Show("Configurações salvas com sucesso.", "Sucesso");
    }
}
