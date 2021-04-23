using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для OtdelAddEditPage.xaml
    /// </summary>
    public partial class OtdelAddEditPage : Page
    {
        Otdel currentOtdel = new Otdel();

        public OtdelAddEditPage(Otdel selectedOtdel)
        {
            InitializeComponent();

            if (selectedOtdel != null)
                currentOtdel = selectedOtdel;

            DataContext = currentOtdel;
        }

        private void BtnAddOtdel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentOtdel.OtdelName))
            {
                MessageBox.Show("Укажите название отделения", "Внимание!");
                return;
            }
            else
            {      
                if (currentOtdel.OtdelID == 0)
                {
                    int count = CollegeDBEntities.GetContext().Otdel.Where(p => p.OtdelName == currentOtdel.OtdelName).Count();

                    if (count > 0)
                    {
                        MessageBoxResult result = MessageBox.Show("Такое отделение уже существует! Продолжить?", "Внимание!", MessageBoxButton.YesNo);

                        if (result == MessageBoxResult.No)
                        {
                            return;
                        }
                    }

                    CollegeDBEntities.GetContext().Otdel.Add(currentOtdel);
                }                

                try
                {
                    CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена успешно!");
                    NavigationManager.OtdelFrame.Navigate(new OtdelViewPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("При попытке сохранения произошла ошибка");
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.OtdelFrame.Navigate(new OtdelViewPage());
        }
    }
}
