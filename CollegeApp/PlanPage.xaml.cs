using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для PlanPage.xaml
    /// </summary>
    public partial class PlanPage : Page
    {
        public PlanPage()
        {
            InitializeComponent();
            planFrame.Navigate(new PlanViewPage());
            NavigationManager.PlanFrame = planFrame;
        }
    }
}
