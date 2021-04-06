using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для GruppaViewPage.xaml
    /// </summary>
    public partial class GruppaViewPage : Page
    {
        public GruppaViewPage()
        {
            InitializeComponent();

            DGridGruppa.ItemsSource = CollegeDBEntities.GetContext().Gruppa.ToList();
            ComboSpecial.ItemsSource = CollegeDBEntities.GetContext().Special.ToList();
        }

        private void BtnAddGruppa_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GruppaFrame.Navigate(new GruppaAddEditPage(null));
        }

        private void GruppaName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboSpecial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DateBegin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DateFinish_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
