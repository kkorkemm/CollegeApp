using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            TextHello.Text += $" {CollegeDBEntities.currentUser.FullName}! ({CollegeDBEntities.currentUser.Role.RoleName})";

            if (CollegeDBEntities.currentUser.RoleID == 5 || CollegeDBEntities.currentUser.RoleID == 6)
            {
                otdelTabFrame.Navigate(new OtdelPage());
                gruppaTabFrame.Navigate(new GruppaPage());
                subjectTabFrame.Navigate(new SubjectPage());
                specialTabFrame.Navigate(new SpecialPage());
                classroomTabFrame.Navigate(new ClassroomPage());
                teacherTabFrame.Navigate(new TeacherPage());
                studentTabFrame.Navigate(new StudentPage());
                planTabFrame.Navigate(new PlanPage());

                tabControl.Items.Remove(tabItemMain);
                tabControl.Items.Remove(tabItemMessage);
                tabControl.Items.Remove(tabItemProfile);
            }
            else
            {
                messageTabFrame.Navigate(new MessageAdminPage());

                if (CollegeDBEntities.currentUser.RoleID == 7)
                {
                    profileTabFrame.Navigate(new TeacherProfilePage(CollegeDBEntities.currentUser));
                    mainTabFrame.Navigate(new ScheduleTeacherPage(CollegeDBEntities.currentUser));
                }
                    
                if (CollegeDBEntities.currentUser.RoleID == 8)
                {
                    mainTabFrame.Navigate(new ScheduleStudentPage(CollegeDBEntities.currentUser));
                    profileTabFrame.Navigate(new StudentProfilePage(CollegeDBEntities.currentUser));
                }

                tabControl.Items.Remove(tabItemTeacher);
                tabControl.Items.Remove(tabItemStudent);
                tabControl.Items.Remove(tabItemSpecial);
                tabControl.Items.Remove(tabItemOtdel);
                tabControl.Items.Remove(tabItemSubject);
                tabControl.Items.Remove(tabItemPlan);
                tabControl.Items.Remove(tabItemGruppa);
                tabControl.Items.Remove(tabItemClassroom);
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new LoginPage());
        }
    }
}
