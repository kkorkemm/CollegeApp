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

            teacherTabFrame.Navigate(new TeacherPage());
            gruppaTabFrame.Navigate(new GruppaPage());
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.MainFrame.Navigate(new LoginPage());
        }
    }
}
