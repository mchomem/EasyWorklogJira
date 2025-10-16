using EasyWorklogJira.WPFApp.Extensions;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EasyWorklogJira.WPFApp.ViewModels;

// ApontamentosViewModel
public class WorklogsViewModel : ViewModelBase
{
    public WorklogsViewModel() { }

    public WorklogsViewModel(MainWindowViewModel mainWindowViewModel)
    {
        Parent = mainWindowViewModel;

        var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        IsBusy = true;

        this.Configuration = mainWindowViewModel.Configuration;
        Configuration = new ConfigurationViewModel();
        Configuration.LoadFromJsonFile();
    }

    private TimeSpan _TotalHoursSpent { get; set; }

    public string TotalHoursSpentShow
    {
        get
        {
            if (_TotalHoursSpent == null)
            {
                return "00:00";
            }

            return _TotalHoursSpent.Hours.ToString("D2") + ":" + _TotalHoursSpent.Minutes.ToString("D2");
        }
    }

    private bool _IsBusy { get; set; }
    public bool IsBusy
    {
        get { return _IsBusy; }
        set
        {
            _IsBusy = value;
            this.OnPropertyChanged(nameof(IsBusy));
            this.OnPropertyChanged(nameof(this.Configuration.IsEnabled));
            this.Configuration.OnPropertyChanged(nameof(this.Configuration.IsEnabled));
            this.OnPropertyChanged(nameof(this.SpinnerVisibility));
            this.OnPropertyChanged(nameof(TasksControlVisibility));
        }
    }

    public MainWindowViewModel Parent { get; set; }

    public ConfigurationViewModel _Configuration { get; set; }

    public ConfigurationViewModel Configuration
    {
        get
        {
            if (_Configuration == null)
            {
                _Configuration = new ConfigurationViewModel();
                _Configuration.LoadFromJsonFile();
            }

            return _Configuration;
        }
        set
        {
            _Configuration = value;
        }
    }

    public ObservableCollection<WorklogDayViewModel> DaysList { get; set; }

    public WorklogDayViewModel SeletedWorklogDay { get; set; }

    public DateTime SelectedDate
    {
        get
        {
            return (Parent ?? new MainWindowViewModel()).SelectedDay;
        }
        set
        {
            if(Parent != null)
            {
                Parent.SelectedDay = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }
    }

    public Visibility SpinnerVisibility
    {
        get
        {
            if (IsBusy)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }
    }

    public Visibility TasksControlVisibility
    {
        get
        {
            if (!IsBusy)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }
    }

    private ICommand _OneDayBeforeClick { get; set; }
    public ICommand OneDayBeforeClick
    {
        get
        {
            return _OneDayBeforeClick ?? (_OneDayBeforeClick = new CommandHandler(() => OneDayBeforeAction(), () => true));
        }
    }

    public void OneDayBeforeAction()
    {

    }
}
