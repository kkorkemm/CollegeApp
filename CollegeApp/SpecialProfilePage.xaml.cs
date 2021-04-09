using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для SpecialProfilePage.xaml
    /// </summary>
    public partial class SpecialProfilePage : Page
    {
        Special currentSpecial = new Special();

        public SpecialProfilePage(Special selectedSpecial)
        {
            InitializeComponent();

            if (selectedSpecial != null)
                currentSpecial = selectedSpecial;

            DataContext = currentSpecial;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SpecialFrame.Navigate(new SpecialAddEditPage(currentSpecial));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SpecialFrame.Navigate(new SpecialViewPage());;
        }
    }
}
