using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для StudentProfilePage.xaml
    /// </summary>
    public partial class StudentProfilePage : Page
    {
        User currentUser = new User();

        public StudentProfilePage(User student)
        {
            InitializeComponent();

            if (student != null)
                currentUser = student;

            if (CollegeDBEntities.currentUser.RoleID == 8)
            {
                BtnEdit.Visibility = Visibility.Hidden;
                BtnBack.Visibility = Visibility.Hidden;
            }

            DataContext = currentUser;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.StudentFrame.Navigate(new StudentViewPage());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.StudentFrame.Navigate(new StudentAddEditPage((sender as Button).DataContext as User));
        }
    }
}
