using System.Windows.Controls;


namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();
            //scheduleFrame.Navigate(new ScheduleViewPage());
            NavigationManager.ScheduleFrame = scheduleFrame;
        }
    }
}
