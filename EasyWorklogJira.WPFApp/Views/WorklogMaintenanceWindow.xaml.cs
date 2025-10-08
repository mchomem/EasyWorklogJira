using System.Media;
using System.Windows;

namespace EasyWorklogJira.WPFApp.Views;

/// <summary>
/// Interaction logic for WorklogMaintenanceWindow.xaml
/// </summary>
public partial class WorklogMaintenanceWindow : Window
{
    public WorklogMaintenanceWindow()
    {
        InitializeComponent();
        maskedTextBoxStartTime.Text = DateTime.Now.ToString("HH:mm");
    }

    private void ButtonSave_Click(object sender, RoutedEventArgs e)
    {
        SystemSounds.Asterisk.Play();
        MessageBox.Show("Registro salvo com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void ButtonClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
