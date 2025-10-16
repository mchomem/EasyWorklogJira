using System.Collections.ObjectModel;
using System.Windows.Media;


namespace EasyWorklogJira.WPFApp.ViewModels
{
    public class WorklogDayViewModel : ViewModelBase
    {
        private ObservableCollection<WorklogViewModel> worklogs;

        public DateTime Day { get; set; }
        public string ExhibitionDay { get { return Day.Day.ToString(); } }
        public string ExhibitionMonth { get { return Day.ToString("MMM"); } }
        public string ExhibitionDayOfWeekLetter { get { return Day.ToString("ddd").ToUpper()[0].ToString(); } }
        public string DayOfWeek { get { return Day.ToString("dddd"); } }
        private bool _IsSelected { get; set; }
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                OnPropertyChanged(nameof(IsSelected));
                OnPropertyChanged(nameof(this.ButtonBackGroundColor));
            }
        }

        public ObservableCollection<WorklogViewModel> Worklog
        {
            get => worklogs;
            set
            {
                worklogs = value;
                OnPropertyChanged(nameof(Worklog));
            }
        }

        public Color ButtonBackGroundColor
        {
            get
            {
                if (IsSelected)
                {
                    return new Color()
                    {
                        ScA = 0.3f,
                        R = 0,
                        G = 115,
                        B = 193
                    };
                }
                else
                {
                    return new Color()
                    {
                        ScA = 0,
                        R = 0,
                        G = 115,
                        B = 193
                    };
                }
            }
        }
    }
}
