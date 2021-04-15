using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для PlanViewPage.xaml
    /// </summary>
    public partial class PlanViewPage : Page
    {
        public PlanViewPage()
        {
            InitializeComponent();

            DGridPlan.ItemsSource = CollegeDBEntities.GetContext().User.Where(p => p.RoleID == 7).ToList();
        }

        private void BtnPlan_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.PlanFrame.Navigate(new PlanTeacherPage((sender as Button).DataContext as User));
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.PlanFrame.Navigate(new ScheduleViewPage((sender as Button).DataContext as User));
        }
    }
}
