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


            var otdels = CollegeDBEntities.GetContext().Otdel.ToList();
            otdels.Insert(0, new Otdel { OtdelName = "Все отделеления"});
            ComboOtdel.ItemsSource = otdels;
            ComboOtdel.SelectedIndex = 0;
        }

        private void BtnAddSpecial_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SpecialFrame.Navigate(new SpecialAddEditPage(null));
        }

        public void UpdateSpecial()
        {
            var currentSpecial = CollegeDBEntities.GetContext().Special.ToList();

            if (TextSpecial.Text != null)
                currentSpecial = currentSpecial.Where(p => p.SpecialName.ToLower().Contains(TextSpecial.Text.ToLower())).ToList();

            if (ComboOtdel.SelectedIndex > 0)
                currentSpecial = currentSpecial.Where(p => p.Otdel == ComboOtdel.SelectedItem as Otdel).ToList();

            DGridSpecial.ItemsSource = currentSpecial;
        }

        private void TextSpecial_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSpecial();
        }

        private void ComboOtdel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSpecial();
        }
    }
}
