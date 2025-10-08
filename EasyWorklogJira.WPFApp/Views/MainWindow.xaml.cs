using System.Windows;

namespace EasyWorklogJira.WPFApp.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ShowDateToday();
    }

    private void ShowDateToday()
    {
        var index = 0;

        TextBlockDateTimeNow.Text = string.Join("", DateTime.Now
            .ToString("dddd - dd/MM/yyyy")
            .Replace(".", string.Empty)
            .Select(x =>
            {
                if (index == 0)
                {
                    index++;
                    x = char.ToUpper(x);
                    return x;
                }

                return x;
            }));
    }

    private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            this.DragMove();
    }

    private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Normal)
            WindowState = WindowState.Minimized;
    }

    private void ButtonClose_Click(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }

    private void buttonGetCalendar_Click(object sender, RoutedEventArgs e)
    {

    }

    private void buttonNew_Click(object sender, RoutedEventArgs e)
    {
        var worklogMaintenanceWindow = new WorklogMaintenanceWindow();
        worklogMaintenanceWindow.Owner = Window.GetWindow(this);
        worklogMaintenanceWindow.ShowDialog();
    }

    private void buttonIssueLiesting_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private void buttonConfiguration_Click(object sender, RoutedEventArgs e)
    {
        var configurationWindow = new ConfigurationWindow();
        configurationWindow.Owner = Window.GetWindow(this);
        configurationWindow.ShowDialog();
    }
}
