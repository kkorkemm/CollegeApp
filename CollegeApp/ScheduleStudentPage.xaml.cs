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
    /// Логика взаимодействия для ScheduleStudentPage.xaml
    /// </summary>
    public partial class ScheduleStudentPage : Page
    {
        User currentStudent = new User();

        public ScheduleStudentPage(User student)
        {
            InitializeComponent();

            if (student != null)
                currentStudent = student;

            DataContext = currentStudent;

            TextName.Text += currentStudent.Student.Gruppa.GruppaName;

            ListSchedule.ItemsSource = CollegeDBEntities.GetContext().Schedule.Where(p => p.LessonPlan.GruppaID == currentStudent.Student.GruppaID).OrderBy(p => p.DayID).ThenBy(p => p.LessonNumId).ToList();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListSchedule.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Day.DayName");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
