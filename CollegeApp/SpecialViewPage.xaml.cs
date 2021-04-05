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
    /// Логика взаимодействия для SpecialViewPage.xaml
    /// </summary>
    public partial class SpecialViewPage : Page
    {
        public SpecialViewPage()
        {
            InitializeComponent();

            DGridSpecial.ItemsSource = CollegeDBEntities.GetContext().Special.ToList();
            ComboOtdel.ItemsSource = CollegeDBEntities.GetContext().Otdel.ToList();
        }

        private void BtnAddSpecial_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SpecialFrame.Navigate(new SpecialAddEditPage(null));
        }
    }
}
