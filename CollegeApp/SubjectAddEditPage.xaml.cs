using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для SubjectAddEditPage.xaml
    /// </summary>
    public partial class SubjectAddEditPage : Page
    {
        Subject currentSubject = new Subject();

        public SubjectAddEditPage(Subject selectedSubject)
        {
            InitializeComponent();

            if (selectedSubject != null)
                currentSubject = selectedSubject;

            DataContext = currentSubject;

            ComboOtdel.ItemsSource = CollegeDBEntities.GetContext().Otdel.ToList();
        }

        private void BtnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(currentSubject.SubjectName))
                errors.AppendLine("Укажите название предмета");
            if (currentSubject.Otdel == null)
                errors.AppendLine("Укажите отделение, которому принадлежит предмет");
            if (currentSubject.Hours < 0)
                errors.AppendLine("Часы введены некорректно");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                if (currentSubject.SubjectID == 0)
                {
                    int count = CollegeDBEntities.GetContext().Subject.Where(p => p.SubjectName == currentSubject.SubjectName).Count();

                    if (count > 0)
                    {
                        MessageBoxResult result = MessageBox.Show("Такой предмет уже существует! Продолжить?", "Внимание!", MessageBoxButton.YesNo);

                        if (result == MessageBoxResult.No)
                        {
                            return;
                        }
                    }

                    CollegeDBEntities.GetContext().Subject.Add(currentSubject);
                }

                try
                {
                    CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена успешно!");

                    NavigationManager.SubjectFrame.Navigate(new SubjectViewPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("При попытке сохранения произошла ошибка!");
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.SubjectFrame.Navigate(new SubjectViewPage());
        }
    }
}
