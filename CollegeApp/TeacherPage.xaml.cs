using System;
using System.Windows.Controls;

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
            teacherFrame.Navigate(new TeacherViewPage());
            NavigationManager.TeacherFrame = teacherFrame;
        }

        private void teacherFrame_ContentRendered(object sender, EventArgs e)
        {
            
        }
    }
}
