namespace EasyWorklogJira.WPFApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        WorklogsViewModel = new WorklogsViewModel(this);
    }

    private DateTime? _SelectedDay { get; set; }
    public DateTime SelectedDay
    {
        get
        {
            return _SelectedDay ?? DateTime.Now;
        }
        set
        {
            _SelectedDay = value;
            OnPropertyChanged(nameof(SelectedDay));
            OnPropertyChanged(nameof(HeaderDate));
        }
    }

    public string HeaderDate
    {
        get
        {
            var ret = SelectedDay.ToString("ddd, dd") + " de " + SelectedDay.ToString("MMMM");
            ret = ret.ToLower();

            return ret.First().ToString().ToUpper() + ret.Substring(1);
        }
    }

    public WorklogsViewModel WorklogsViewModel { get; set; }

    public ConfigurationViewModel Configuration { get; set; }
}
