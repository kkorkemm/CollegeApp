using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для ScheduleAddPage.xaml
    /// </summary>
    public partial class ScheduleAddPage : Page
    {
        Schedule schedule = new Schedule();
        User currentTeacher = new User();

        public ScheduleAddPage(User teacher)
        {
            InitializeComponent();

            if (teacher != null)
                currentTeacher = teacher;

            DataContext = schedule;

            TextTeacherName.Text += currentTeacher.FullName;
            ComboLessonPlan.ItemsSource = CollegeDBEntities.GetContext().LessonPlan.Where(p => p.UserID == currentTeacher.UserID).ToList();
            ComboDay.ItemsSource = CollegeDBEntities.GetContext().Day.ToList();
            ComboClassroom.ItemsSource = CollegeDBEntities.GetContext().Classroom.Where(p => p.Active == true).ToList();
            ComboLessonNum.ItemsSource = CollegeDBEntities.GetContext().LessonNum.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (schedule.LessonPlan == null)
                errors.AppendLine("Укажите пункт в плане");
            if (schedule.Day == null)
                errors.AppendLine("Укажите день недели");
            if (schedule.LessonNum == null)
                errors.AppendLine("Укажите номер пары");
            if (schedule.Classroom == null)
                errors.AppendLine("Укажите аудиторию");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {

                if (CollegeDBEntities.GetContext().Schedule.Where(p => p.LessonPlan.GruppaID == schedule.LessonPlan.GruppaID && p.DayID == schedule.Day.DayID && p.LessonNumId == schedule.LessonNum.LessonNumID).Count() > 0)
                {
                    MessageBox.Show("Расписание для группы на этот день и пару уже занято!");
                    return;
                }

                if (CollegeDBEntities.GetContext().Schedule.Where(p => p.LessonPlan.UserID == schedule.LessonPlan.UserID && p.DayID == schedule.Day.DayID && p.LessonNumId == schedule.LessonNum.LessonNumID).Count() > 0)
                {
                    MessageBox.Show("Расписание для преподавателя на этот день и пару уже занято!");
                    return;
                }

                if (schedule.ScheduleID == 0)
                    CollegeDBEntities.GetContext().Schedule.Add(schedule);

                try
                {
                    CollegeDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!");
                    NavigationManager.PlanFrame.Navigate(new ScheduleViewPage(currentTeacher));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.PlanFrame.Navigate(new ScheduleViewPage(currentTeacher));
        }
    }
}
