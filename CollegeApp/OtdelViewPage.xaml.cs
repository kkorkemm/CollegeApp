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
    /// Логика взаимодействия для OtdelViewPage.xaml
    /// </summary>
    public partial class OtdelViewPage : Page
    {
        public OtdelViewPage()
        {
            InitializeComponent();

            DGridOtdel.ItemsSource = CollegeDBEntities.GetContext().Otdel.ToList();
        }

        private void BtnAddOtdel_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.OtdelFrame.Navigate(new OtdelAddEditPage(null));
        }

        private void TextOtdel_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentOtdel = CollegeDBEntities.GetContext().Otdel.ToList();

            if (!string.IsNullOrWhiteSpace(TextOtdel.Text))
            {
               currentOtdel = currentOtdel.Where(p => p.OtdelName.ToLower().Contains(TextOtdel.Text.ToLower())).ToList();
            }

            DGridOtdel.ItemsSource = currentOtdel;
        }
    }
}
