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

            var special = CollegeDBEntities.GetContext().Special.ToList();
            special.Insert(0, new Special { SpecialName = "Все специальности" });
            ComboSpecial.ItemsSource = special;
            ComboSpecial.SelectedIndex = 0;
        }

        private void BtnAddGruppa_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GruppaFrame.Navigate(new GruppaAddEditPage(null));
        }

        public void UpdateGruppa()
        {
            var currentGruppa = CollegeDBEntities.GetContext().Gruppa.ToList();

            if (!string.IsNullOrWhiteSpace(GruppaName.Text))
                currentGruppa = currentGruppa.Where(p=>p.GruppaName.ToLower().Contains(GruppaName.Text.ToLower())).ToList();

            if (ComboSpecial.SelectedIndex > 0)
                currentGruppa = currentGruppa.Where(p=>p.Special == ComboSpecial.SelectedItem as Special).ToList();

            if (DateBegin.SelectedDate != null)
                currentGruppa = currentGruppa.Where(p=>p.BeginDate == DateBegin.SelectedDate).ToList();

            if (DateFinish.SelectedDate != null)
                currentGruppa = currentGruppa.Where(p => p.FinishDate == DateFinish.SelectedDate).ToList();

            DGridGruppa.ItemsSource = currentGruppa;
        }

        private void GruppaName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateGruppa();
        }

        private void ComboSpecial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGruppa();
        }

        private void DateBegin_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGruppa();
        }

        private void DateFinish_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateGruppa();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GruppaFrame.Navigate(new GruppaProfilePage((sender as Button).DataContext as Gruppa));
        }
    }
}
