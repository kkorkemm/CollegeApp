using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            var profilePage = new SpecialProfilePage((sender as Button).DataContext as Special);
            NavigationManager.SpecialFrame.NavigationService.Navigate(profilePage);
        }
    }
}
