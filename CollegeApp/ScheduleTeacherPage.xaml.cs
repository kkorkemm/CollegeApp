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
    /// Логика взаимодействия для ScheduleTeacherPage.xaml
    /// </summary>
    public partial class ScheduleTeacherPage : Page
    {
        User currentTeacher = new User();

        public ScheduleTeacherPage(User teacher)
        {
            InitializeComponent();

            if (teacher != null)
                currentTeacher = teacher;

            DataContext = currentTeacher;

            TextName.Text += currentTeacher.FullName;

            ListSchedule.ItemsSource = CollegeDBEntities.GetContext().Schedule.Where(p => p.LessonPlan.UserID == currentTeacher.UserID).OrderBy(p => p.DayID).ThenBy(p => p.LessonNumId).ToList();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListSchedule.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Day.DayName");
            view.GroupDescriptions.Add(groupDescription);
        }
    }
}
