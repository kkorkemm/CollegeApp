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
    /// Логика взаимодействия для SubjectViewPage.xaml
    /// </summary>
    public partial class SubjectViewPage : Page
    {
        public SubjectViewPage()
        {
            InitializeComponent();

            DGridSubject.ItemsSource = CollegeDBEntities.GetContext().Subject.ToList();

            var otdels = CollegeDBEntities.GetContext().Otdel.ToList();
            otdels.Insert(0, new Otdel { OtdelName = "Все отделения" });
            ComboOtdel.ItemsSource = otdels;
            ComboOtdel.SelectedIndex = 0;
        }

        private void BtnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SubjectFrame.Navigate(new SubjectAddEditPage(null));
        }


        public void UpdateSubject()
        {
            var currentSubject = CollegeDBEntities.GetContext().Subject.ToList();

            if (!string.IsNullOrWhiteSpace(TextSubject.Text))
            {
                currentSubject = currentSubject.Where(p => p.SubjectName.ToLower().Contains(TextSubject.Text.ToLower())).ToList();
            }

            if (ComboOtdel.SelectedIndex > 0)
            {
                currentSubject = currentSubject.Where(p => p.Otdel == ComboOtdel.SelectedItem as Otdel).ToList();
            }

            DGridSubject.ItemsSource = currentSubject;
        }

        private void TextSubject_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSubject();
        }

        private void ComboOtdel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSubject();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SubjectFrame.Navigate(new SubjectProfilePage((sender as Button).DataContext as Subject));
        }
    }
}
