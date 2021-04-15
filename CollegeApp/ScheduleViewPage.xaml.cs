using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для ScheduleViewPage.xaml
    /// </summary>
    public partial class ScheduleViewPage : Page
    {
        Schedule schedule = new Schedule();
        User currentTeacher = new User();

        public ScheduleViewPage(User teacher)
        {
            InitializeComponent();

            if (teacher != null)
                currentTeacher = teacher;

            TextTeacherName.Text += currentTeacher.FullName;
            DataContext = schedule;

            DGridSchedule.ItemsSource = CollegeDBEntities.GetContext().Schedule.Where(p => p.LessonPlan.UserID == currentTeacher.UserID).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.PlanFrame.Navigate(new PlanViewPage());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.PlanFrame.Navigate(new ScheduleAddPage(currentTeacher));
        }
    }
}
