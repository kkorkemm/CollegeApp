using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для TeacherViewPage.xaml
    /// </summary>
    public partial class TeacherViewPage : Page
    {
        public TeacherViewPage()
        {
            InitializeComponent();

            DGridTeacher.ItemsSource = CollegeDBEntities.GetContext().User.Where(p => p.RoleID == 7).ToList();

            var otdels = CollegeDBEntities.GetContext().Otdel.ToList();
            otdels.Insert(0, new Otdel { OtdelName = "Все отделения" });

            var genders = CollegeDBEntities.GetContext().Gender.ToList();
            genders.Insert(0, new Gender { GenderName = "Не выбрано" });

            ComboGender.ItemsSource = genders;
            ComboGender.SelectedIndex = 0;
            ComboOtdel.ItemsSource = otdels;
            ComboOtdel.SelectedIndex = 0;
        }

        private void BtnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.TeacherFrame.Navigate(new TeacherAddPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.TeacherFrame.Navigate(new TeacherProfilePage((sender as Button).DataContext as User));
        }

        public void UpdateTeacher()
        {
            var result = CollegeDBEntities.GetContext().User.Where(p => p.RoleID == 7).ToList();

            if (!string.IsNullOrWhiteSpace(TextUserName.Text))
                result = result.Where(p => p.FullName.ToLower().Contains(TextUserName.Text.ToLower())).ToList();

            if (ComboGender.SelectedIndex > 0)
                result = result.Where(p => p.Gender == ComboGender.SelectedItem as Gender).ToList();

            if (ComboOtdel.SelectedIndex > 0)
                result = result.Where(p => p.Teacher.Otdel == ComboOtdel.SelectedItem as Otdel).ToList();

            if (DateBirth.SelectedDate != null)
                result = result.Where(p => p.BirthDate == DateBirth.SelectedDate).ToList();

            DGridTeacher.ItemsSource = result;
        }

        private void TextUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTeacher();
        }

        private void ComboOtdel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTeacher();
        }

        private void ComboGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTeacher();
        }

        private void DateBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTeacher();
        }
    }
}
