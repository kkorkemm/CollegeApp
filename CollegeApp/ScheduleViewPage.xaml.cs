using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

            if (CollegeDBEntities.currentUser.RoleID == 7 || CollegeDBEntities.currentUser.RoleID == 8)
            {
                BtnAdd.Visibility = Visibility.Hidden;
                BtnBack.Visibility = Visibility.Hidden;
            }

            if (CollegeDBEntities.currentUser.RoleID == 8)
                TextTeacherName.Text = "Расписание для студента: ";

            TextTeacherName.Text += currentTeacher.FullName;
            DataContext = schedule;

            DGridSchedule.ItemsSource = CollegeDBEntities.GetContext().Schedule.Where(p => p.LessonPlan.UserID == currentTeacher.UserID).OrderBy(p => p.DayID).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var removingSchedule = DGridSchedule.SelectedItem as Schedule;

            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить пункт из расписания?", "Внимание!", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    CollegeDBEntities.GetContext().Schedule.Remove(removingSchedule);
                    CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно удалены!");
                    DGridSchedule.ItemsSource = CollegeDBEntities.GetContext().Schedule.Where(p => p.LessonPlan.UserID == currentTeacher.UserID).OrderBy(p => p.DayID).ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
