using System;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для ClassroomProfilePage.xaml
    /// </summary>
    public partial class ClassroomProfilePage : Page
    {
        Classroom currentClassroom = new Classroom();

        public ClassroomProfilePage(Classroom classroom)
        {
            InitializeComponent();

            if (classroom != null)
                currentClassroom = classroom;

            DataContext = currentClassroom;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.ClassroomFrame.Navigate(new ClassroomAddEditPage(currentClassroom));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.ClassroomFrame.Navigate(new ClassroomViewPage());
        }
    }
}
