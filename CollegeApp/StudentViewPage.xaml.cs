using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для StudentViewPage.xaml
    /// </summary>
    public partial class StudentViewPage : Page
    {
        public StudentViewPage()
        {
            InitializeComponent();

            var gruppas = CollegeDBEntities.GetContext().Gruppa.ToList();
            gruppas.Insert(0, new Gruppa { GruppaName = "Все группы" });

            var genders = CollegeDBEntities.GetContext().Gender.ToList();
            genders.Insert(0, new Gender { GenderName = "Не выбрано" });

            ComboGruppa.ItemsSource = gruppas;
            ComboGruppa.SelectedIndex = 0;

            ComboGender.ItemsSource = genders;
            ComboGender.SelectedIndex = 0;

            DGridStudent.ItemsSource = CollegeDBEntities.GetContext().User.Where(p => p.RoleID == 8).ToList();
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.StudentFrame.Navigate(new StudentAddEditPage(null));
        }

        public void UpdateStudents()
        {
            var result = CollegeDBEntities.GetContext().User.Where(p => p.RoleID == 8).ToList();

            if (!string.IsNullOrWhiteSpace(TextUserName.Text))
                result = result.Where(p => p.FullName.ToLower().Contains(TextUserName.Text.ToLower())).ToList();

            if (ComboGender.SelectedIndex > 0)
                result = result.Where(p => p.Gender == ComboGender.SelectedItem as Gender).ToList();

            if (ComboGruppa.SelectedIndex > 0)
                result = result.Where(p => p.Student.Gruppa == ComboGruppa.SelectedItem as Gruppa).ToList();

            if (!string.IsNullOrEmpty(TextZachetka.Text))
                result = result.Where(p => p.Student.Zachetka.ToLower().Contains(TextZachetka.Text.ToLower())).ToList();

            if (DateBirth.SelectedDate != null)
                result = result.Where(p => p.BirthDate == DateBirth.SelectedDate).ToList();

            DGridStudent.ItemsSource = result;

        }

        private void ComboGruppa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStudents();
        }

        private void TextZachetka_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateStudents();
        }

        private void TextUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateStudents();
        }

        private void ComboGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStudents();
        }

        private void DateBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateStudents();
        }

        private void BtnView_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.StudentFrame.Navigate(new StudentProfilePage((sender as Button).DataContext as User));
        }
    }
}
