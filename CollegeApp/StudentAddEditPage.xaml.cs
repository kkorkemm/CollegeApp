using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для StudentAddEditPage.xaml
    /// </summary>
    public partial class StudentAddEditPage : Page
    {
        User currentUser = new User();

        public StudentAddEditPage(User selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
                currentUser = selectedUser;

            DataContext = currentUser;

            ComboGender.ItemsSource = CollegeDBEntities.GetContext().Gender.ToList();
            ComboGruppa.ItemsSource = CollegeDBEntities.GetContext().Gruppa.ToList();
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentUser.Surname))
                errors.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(currentUser.Name))
                errors.AppendLine("Введите имя");
            if (currentUser.Gender == null)
                errors.AppendLine("Укажите пол");
            if (currentUser.BirthDate == null)
                errors.AppendLine("Укажите дату рождения");
            if (string.IsNullOrWhiteSpace(currentUser.Login))
                errors.AppendLine("Введите логин");
            if (string.IsNullOrWhiteSpace(currentUser.Password))
                errors.AppendLine("Введите пароль");

            if (ComboGruppa.SelectedItem == null)
                errors.AppendLine("Укажите группу");
            if (string.IsNullOrWhiteSpace(TextZach.Text))
                errors.AppendLine("Введите номер зачетки");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                currentUser.RoleID = 8;

                if (currentUser.UserID == 0)
                {
                    CollegeDBEntities.GetContext().User.Add(currentUser);

                    Student student = new Student
                    {
                        UserID = currentUser.UserID,
                        Gruppa = ComboGruppa.SelectedItem as Gruppa,
                        Zachetka = TextZach.Text
                    };

                    CollegeDBEntities.GetContext().Student.Add(student);
                }

                try
                {
                    CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена успешно!", "Внимание!");
                    NavigationManager.StudentFrame.Navigate(new StudentViewPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.StudentFrame.Navigate(new StudentViewPage());
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

                ImageUser.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }
    }
}
