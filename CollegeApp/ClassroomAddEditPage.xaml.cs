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
                    CollegeDBEntities.GetContext().Classroom.Add(currentClassroom);

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
