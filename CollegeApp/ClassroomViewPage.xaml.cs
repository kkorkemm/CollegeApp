using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для ClassroomViewPage.xaml
    /// </summary>
    public partial class ClassroomViewPage : Page
    {
        public ClassroomViewPage()
        {
            InitializeComponent();

            DGridClassroom.ItemsSource = CollegeDBEntities.GetContext().Classroom.ToList();
        }

        private void BtnAddClassroom_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.ClassroomFrame.Navigate(new ClassroomAddEditPage(null));
        }

        private void TextClassroom_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentClassroom = CollegeDBEntities.GetContext().Classroom.Where(p => p.ClassroomName.Contains(TextClassroom.Text)).ToList();

            DGridClassroom.ItemsSource = currentClassroom;
        }
    }
}
