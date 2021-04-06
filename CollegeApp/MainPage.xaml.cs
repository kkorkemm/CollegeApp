using System;
using System.Collections.Generic;
using System.Linq;
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
            TextHello.Text += $" {CollegeDBEntities.UserFullName}! ({CollegeDBEntities.UserRole})";

            otdelTabFrame.Navigate(new OtdelPage());
            gruppaTabFrame.Navigate(new GruppaPage());
            subjectTabFrame.Navigate(new SubjectPage());
            specialTabFrame.Navigate(new SpecialPage());
            classroomTabFrame.Navigate(new ClassroomPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new LoginPage());
        }

        private void otdelTabFrame_ContentRendered(object sender, EventArgs e)
        {
            //if (NavigationManager.OtdelFrame.CanGoBack)
            //    BtnBackOtdel.Visibility = Visibility.Visible;
            //else
            //    BtnBackOtdel.Visibility = Visibility.Visible;
        }
        private void BtnBackOtdel_Click(object sender, RoutedEventArgs e)
        {
            //NavigationManager.OtdelFrame.GoBack();
        }
    }
}
