using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
            if (string.IsNullOrWhiteSpace(currentUser.Login))
                errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(currentUser.Password))
                errors.AppendLine("Введите пароль");
            if (currentUser.Gender == null)
                errors.AppendLine("Укажите пол");
            if (ComboOtdel.SelectedItem == null)
                errors.AppendLine("Укажите отделение");
            if (currentUser.BirthDate == null)
                errors.AppendLine("Укажите дату рождения");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                currentUser.RoleID = 7;

                if (currentUser.UserID == 0)
                {
                    CollegeDBEntities.GetContext().User.Add(currentUser);

                    Teacher currentTeacher = new Teacher();
                    currentTeacher.UserID = currentUser.UserID;
                    currentTeacher.Otdel = ComboOtdel.SelectedItem as Otdel;
                    currentTeacher.HasHighEducation = (bool)CheckHigh.IsChecked;

                    CollegeDBEntities.GetContext().Teacher.Add(currentTeacher);
                }
   
                try
                {
                    CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация успешно сохранена!");

                    NavigationManager.TeacherFrame.Navigate(new TeacherViewPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("Произвошла ошибка при попытке сохранения данных");
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.TeacherFrame.Navigate(new TeacherViewPage());
        }

        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "Image Files(*.png; *.jpeg; *.jpg) | *.png; *.jpeg; *.jpg"
            };

            if (fileDialog.ShowDialog() == true)
            {

                byte[] imageData;
                using (FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                }

                currentUser.UserPhoto = imageData;

                //ImageUser.Source = new BitmapImage(new Uri(fileDialog.FileName));
                ImageUser.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }
    }
}
