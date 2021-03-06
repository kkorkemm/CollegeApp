using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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
            {
                currentSpecial = selectedSpecial;
                textMain.Text = "Редактирование специальности";
            }
                
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
                {
                    int count = CollegeDBEntities.GetContext().Special.Where(p => p.SpecialName == currentSpecial.SpecialName).Count();

                    if (count > 0)
                    {
                        MessageBoxResult result = MessageBox.Show("Такая специальность уже существует! Продолжить?", "Внимание!", MessageBoxButton.YesNo);

                        if (result == MessageBoxResult.No)
                        {
                            return;
                        }
                    }

                    CollegeDBEntities.GetContext().Special.Add(currentSpecial);
                }

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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SpecialFrame.Navigate(new SpecialViewPage());
        }
    }
}
