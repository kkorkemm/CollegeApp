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
    /// Логика взаимодействия для GruppaPage.xaml
    /// </summary>
    public partial class GruppaPage : Page
    {
        public GruppaPage()
        {
            InitializeComponent();
            NavigationManager.GruppaFrame = gruppaName;
            NavigationManager.GruppaFrame.Navigate(new GruppaViewPage());
        }

        private void gruppaName_ContentRendered(object sender, EventArgs e)
        {
            if (NavigationManager.GruppaFrame.CanGoBack)
                BtnBack.Visibility = Visibility.Visible;
            else
                BtnBack.Visibility = Visibility.Hidden;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GruppaFrame.GoBack();
        }
    }
}
