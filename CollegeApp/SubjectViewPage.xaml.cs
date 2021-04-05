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
    /// Логика взаимодействия для SubjectViewPage.xaml
    /// </summary>
    public partial class SubjectViewPage : Page
    {
        public SubjectViewPage()
        {
            InitializeComponent();

            ComboOtdel.ItemsSource = CollegeDBEntities.GetContext().Otdel.ToList();
            DGridSubject.ItemsSource = CollegeDBEntities.GetContext().Subject.ToList();
        }

        private void BtnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SubjectFrame.Navigate(new SubjectAddEditPage(null));
        }
    }
}
