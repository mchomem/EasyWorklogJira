using System.Diagnostics;
using System.Media;
using System.Windows;

namespace EasyWorklogJira.WPFApp.Views;

/// <summary>
/// Interaction logic for ConfigurationWindow.xaml
/// </summary>
public partial class ConfigurationWindow : Window
{
    public ConfigurationWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // TODO: load json config
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
        SystemSounds.Asterisk.Play();
        MessageBox.Show("Configurações salvas com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void buttonClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }    
}
