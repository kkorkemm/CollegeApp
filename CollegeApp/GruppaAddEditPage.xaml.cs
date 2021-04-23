using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для GruppaAddEditPage.xaml
    /// </summary>
    public partial class GruppaAddEditPage : Page
    {
        Gruppa currentGruppa = new Gruppa();

        public GruppaAddEditPage(Gruppa selectedGruppa)
        {
            InitializeComponent();

            if (selectedGruppa != null)
                currentGruppa = selectedGruppa;

            DataContext = currentGruppa;

            ComboSpecial.ItemsSource = CollegeDBEntities.GetContext().Special.ToList();
        }

        private void BtnAddGruppa_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentGruppa.GruppaName))
                errors.AppendLine("Укажите название группы");
            if (currentGruppa.Special == null)
                errors.AppendLine("Укажите специальность группы");
            if (currentGruppa.BeginDate == null)
                errors.AppendLine("Укажите дату поступления студентов группы");
            if (currentGruppa.FinishDate == null)
                errors.AppendLine("Укажите дату выпуска студентов группы");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
               
                if (currentGruppa.GruppaID == 0)
                {
                    int count = CollegeDBEntities.GetContext().Gruppa.Where(p => p.GruppaName == currentGruppa.GruppaName).Count();

                    if (count > 0)
                    {
                        MessageBoxResult result = MessageBox.Show("Такая группа уже существует!", "Внимание!", MessageBoxButton.YesNo);

                        if (result == MessageBoxResult.No)
                            return;
                    }

                    CollegeDBEntities.GetContext().Gruppa.Add(currentGruppa);
                }
                  
                try
                {
                    CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация успешно сохранена!");

                    NavigationManager.GruppaFrame.Navigate(new GruppaViewPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("При попытке сохранения произошла ошибка");
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GruppaFrame.Navigate(new GruppaViewPage());
        }
    }
}
