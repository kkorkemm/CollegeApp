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
    /// Логика взаимодействия для TeacherAddPage.xaml
    /// </summary>
    public partial class TeacherAddPage : Page
    {
        User currentUser = new User();

        public TeacherAddPage(User selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
                currentUser = selectedUser;

            DataContext = currentUser;

            ComboGender.ItemsSource = CollegeDBEntities.GetContext().Gender.ToList();
            ComboOtdel.ItemsSource = CollegeDBEntities.GetContext().Otdel.ToList();
        }

        private void BtnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentUser.Surname))
                errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(currentUser.Name))
                errors.AppendLine("Введите имя");
            if (string.IsNullOrWhiteSpace(currentUser.LastName))
                errors.AppendLine("Введите отчество");
            if (string.IsNullOrWhiteSpace(currentUser.Login))
                errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(currentUser.Password))
                errors.AppendLine("Введите пароль");
            if (ComboGender.SelectedItem == null)
                errors.AppendLine("Укажите пол");
            if (ComboOtdel.SelectedItem == null)
                errors.AppendLine("Укажите отделение");
            if (DateBirth.SelectedDate == null)
                errors.AppendLine("Укажите дату рождения");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                currentUser.RoleID = 7;

                


                try
                {
                    //CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация успешно сохранена!");

                    NavigationManager.TeacherFrame.Navigate(new TeacherViewPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("Произвошла ошибка при попытке сохранения данных");
                }
            }
        }
    }
}
