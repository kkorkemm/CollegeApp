using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для ClassroomAddEditPage.xaml
    /// </summary>
    public partial class ClassroomAddEditPage : Page
    {
        Classroom currentClassroom = new Classroom();

        public ClassroomAddEditPage(Classroom selectedClassroom)
        {
            InitializeComponent();

            if (selectedClassroom != null)
                currentClassroom = selectedClassroom;

            DataContext = currentClassroom;

        }

        private void BtnAddClassroom_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currentClassroom.ClassroomName))
            {
                MessageBox.Show("Введите название/номер аудитории");
                return;
            }
            else
            {
                
                if (currentClassroom.ClassroomID == 0)
                {
                    int count = CollegeDBEntities.GetContext().Classroom.Where(p => p.ClassroomName == currentClassroom.ClassroomName).Count();

                    if (count > 0)
                    {
                        MessageBoxResult result = MessageBox.Show("Такая аудитория уже существует! Продолжить?", "Внимание!", MessageBoxButton.YesNo);

                        if (result == MessageBoxResult.No)
                        {
                            return;
                        }
                    }

                    CollegeDBEntities.GetContext().Classroom.Add(currentClassroom);
                }
                   
                try
                {
                    CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Информация сохранена успешно!");
                    NavigationManager.ClassroomFrame.Navigate(new ClassroomViewPage());
                }
                catch (Exception)
                {
                    MessageBox.Show("При попытке сохранения произошла ошибка");
                }
            }
                
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.ClassroomFrame.Navigate(new ClassroomViewPage());
        }
    }
}
