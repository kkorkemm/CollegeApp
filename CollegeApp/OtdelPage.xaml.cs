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
    /// Логика взаимодействия для OtdelPage.xaml
    /// </summary>
    public partial class OtdelPage : Page
    {
        public OtdelPage()
        {
            InitializeComponent();
            otdelFrame.Navigate(new OtdelViewPage());
            NavigationManager.OtdelFrame = otdelFrame;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.OtdelFrame.GoBack();
        }

        private void otdelFrame_ContentRendered(object sender, EventArgs e)
        {
            if (NavigationManager.OtdelFrame.CanGoBack)
                BtnBack.Visibility = Visibility.Visible;
            else
                BtnBack.Visibility = Visibility.Hidden;
        }
    }
}
