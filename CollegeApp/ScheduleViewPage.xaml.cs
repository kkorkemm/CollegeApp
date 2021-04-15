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
        public ScheduleViewPage()
        {
            InitializeComponent();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.ScheduleFrame.Navigate(new PlanViewPage());
        }
    }
}
