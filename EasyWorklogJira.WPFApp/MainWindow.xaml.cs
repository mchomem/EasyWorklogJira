using EasyWorklogJira.WPFApp.Views;
using System.Windows;

namespace EasyWorklogJira.WPFApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void buttonIssueCalendar_Click(object sender, RoutedEventArgs e)
    {

    }

    private void buttonNew_Click(object sender, RoutedEventArgs e)
    {

    }

    private void buttonHome_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new WorklogListingView();
    }

    private void buttonSettings_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new SettingsView();
    }
}