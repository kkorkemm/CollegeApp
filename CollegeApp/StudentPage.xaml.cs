using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        public StudentPage()
        {
            InitializeComponent();

            studentFrame.Navigate(new StudentViewPage());
            NavigationManager.StudentFrame = studentFrame;
        }
    }
}
