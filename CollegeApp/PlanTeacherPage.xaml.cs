using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для PlanTeacherPage.xaml
    /// </summary>
    public partial class PlanTeacherPage : Page
    {
        LessonPlan lessonPlan = new LessonPlan();
        User currentTeacher = new User();

        public PlanTeacherPage(User teacher)
        {
            InitializeComponent();

            if (teacher != null)
                currentTeacher = teacher;

            lessonPlan.User = currentTeacher;
            DataContext = lessonPlan;

            DGridTeacherPlan.ItemsSource = CollegeDBEntities.GetContext().LessonPlan.Where(p => p.UserID == currentTeacher.UserID).ToList();
            TextTeacherName.Text += currentTeacher.FullName;
        }

        private void BtnAddPlan_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.PlanFrame.Navigate(new PlanTeacherAddPage(currentTeacher));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.PlanFrame.Navigate(new PlanViewPage());
        }

        private void BtnDeletePlan_Click(object sender, RoutedEventArgs e)
        {
            var removingPlan = DGridTeacherPlan.SelectedItem as LessonPlan;

            MessageBoxResult messageBoxResult = MessageBox.Show($"Вы точно хотите удалить пункт плана для группы {removingPlan.Gruppa.GruppaName}?", "Внимание!", MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                try
                {
                    CollegeDBEntities.GetContext().LessonPlan.Remove(removingPlan);
                    CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация удалена успешно!");
                    DGridTeacherPlan.ItemsSource = CollegeDBEntities.GetContext().LessonPlan.Where(p => p.UserID == currentTeacher.UserID).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
