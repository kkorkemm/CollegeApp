using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            ComboLogin.ItemsSource = CollegeDBEntities.GetContext().User.Where(p=>p.Active == true).OrderBy(p => p.Login).ToList();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ComboLogin.SelectedItem == null || TextPassword.Password == null || TextPassword.Password == " ")
            {
                MessageBox.Show("Введите логин и пароль", "Внимание!");
            }
            else
            {
                if (ComboLogin.SelectedItem is User currentUser)
                {
                    if (TextPassword.Password == currentUser.Password)
                    {
                        CollegeDBEntities.currentUser = currentUser;
                        NavigationManager.MainFrame.Navigate(new MainPage());
                    }

                    else
                    {
                        MessageBox.Show("Неверный пароль", "Внимание!");
                    }
                }
            }
        }
    }
}
