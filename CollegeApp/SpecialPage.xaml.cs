using System;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для SpecialPage.xaml
    /// </summary>
    public partial class SpecialPage : Page
    {
        public SpecialPage()
        {
            InitializeComponent();
            specialFrame.NavigationService.Navigate(new SpecialViewPage());
            NavigationManager.SpecialFrame = specialFrame;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SpecialFrame.GoBack();
        }

        private void specialFrame_ContentRendered(object sender, EventArgs e)
        {
            if (NavigationManager.SpecialFrame.CanGoBack)
                BtnBack.Visibility = Visibility.Visible;
            else
                BtnBack.Visibility = Visibility.Hidden;
        }
    }
}
