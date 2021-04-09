using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для SubjectProfilePage.xaml
    /// </summary>
    public partial class SubjectProfilePage : Page
    {
        Subject currentSubject = new Subject();

        public SubjectProfilePage(Subject subject)
        {
            InitializeComponent();

            if (subject != null)
                currentSubject = subject;

            DataContext = currentSubject;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SubjectFrame.Navigate(new SubjectViewPage());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SubjectFrame.Navigate(new SubjectAddEditPage((sender as Button).DataContext as Subject));
        }
    }
}
