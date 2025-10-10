using EasyWorklogJira.WPFApp.Extensions;
using System.Windows.Input;

namespace EasyWorklogJira.WPFApp.ViewModels;

// ApontamentosViewModel
public class WorklogsViewModel : ViewModelBase
{
    public WorklogsViewModel() { }

    public WorklogsViewModel(MainWindowViewModel mainWindowViewModel) { }

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
