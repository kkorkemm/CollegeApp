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
    /// Логика взаимодействия для TeacherViewPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
            NavigationManager.TeacherFrame = teacherFrame;
            NavigationManager.TeacherFrame.Navigate(new TeacherViewPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.TeacherFrame.GoBack();
        }

        private void teacherFrame_ContentRendered(object sender, EventArgs e)
        {
            //if (NavigationManager.TeacherFrame.CanGoBack)
            //    BtnBack.Visibility = Visibility.Visible;
            //else
            //    BtnBack.Visibility = Visibility.Hidden;
        }
    }
}
