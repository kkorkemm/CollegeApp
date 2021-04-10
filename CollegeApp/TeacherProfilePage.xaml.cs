using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для TeacherProfilePage.xaml
    /// </summary>
    public partial class TeacherProfilePage : Page
    {
        User currentTeacher = new User();

        public TeacherProfilePage(User teacher)
        {
            InitializeComponent();

            if (teacher != null)
                currentTeacher = teacher;

            DataContext = currentTeacher;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.TeacherFrame.Navigate(new TeacherViewPage());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.TeacherFrame.Navigate(new TeacherAddPage(currentTeacher));
        }
    }
}
