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
    /// Логика взаимодействия для SpecialAddEditPage.xaml
    /// </summary>
    public partial class SpecialAddEditPage : Page
    {
        Special currentSpecial = new Special();

        public SpecialAddEditPage(Special selectedSpecial)
        {
            InitializeComponent();

            if (selectedSpecial != null)
                currentSpecial = selectedSpecial;

            DataContext = currentSpecial;

            ComboOtdel.ItemsSource = CollegeDBEntities.GetContext().Otdel.ToList();
        }

        private void BtnAddSpecial_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentSpecial.SpecialName))
                errors.AppendLine("Укажите название специальности");
            if (currentSpecial.Otdel == null)
                errors.AppendLine("Укажите отделение");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (currentSpecial.SpecialID == 0)
                    CollegeDBEntities.GetContext().Special.Add(currentSpecial);

                try
                {
                    CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена успешно!");
                    NavigationManager.SpecialFrame.Navigate(new SpecialViewPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("При попытке сохранения произошла ошибка");
                }
            }
        }
    }
}
