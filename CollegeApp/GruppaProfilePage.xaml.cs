using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для GruppaProfilePage.xaml
    /// </summary>
    public partial class GruppaProfilePage : Page
    {
        Gruppa currentGruppa = new Gruppa();

        public GruppaProfilePage(Gruppa gruppa)
        {
            InitializeComponent();

            if (gruppa != null)
                currentGruppa = gruppa;

            DataContext = currentGruppa;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GruppaFrame.Navigate(new GruppaAddEditPage(currentGruppa));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GruppaFrame.Navigate(new GruppaViewPage());
        }
    }
}
