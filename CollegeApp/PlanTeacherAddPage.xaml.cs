using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CollegeApp
{
    /// <summary>
    /// Логика взаимодействия для PlanTeacherAddPage.xaml
    /// </summary>
    public partial class PlanTeacherAddPage : Page
    {
        LessonPlan lessonPlan = new LessonPlan();
        User currentTeacher = new User();

        public PlanTeacherAddPage(User teacher)
        {
            InitializeComponent();

            if (teacher != null)
                currentTeacher = teacher;

            lessonPlan.User = currentTeacher;
            DataContext = lessonPlan;

            TextTeacherName.Text += currentTeacher.FullName;
            ComboGruppas.ItemsSource = CollegeDBEntities.GetContext().Gruppa.Where(p => p.Active == true).ToList();
            ComboSubjects.ItemsSource = CollegeDBEntities.GetContext().Subject.Where(p => p.Active == true).ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (lessonPlan.Gruppa == null)
                errors.AppendLine("Укажите группу");
            if (lessonPlan.Subject == null)
                errors.AppendLine("Укажите предмет");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                int count = CollegeDBEntities.GetContext().LessonPlan.Where(p => p.GruppaID == lessonPlan.Gruppa.GruppaID && p.SubjectID == lessonPlan.Subject.SubjectID).Count();

                if (count > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Данной группе уже ведется такой предмет! Продолжить?", "Внимание!", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.No)
                    {
                        return;
                    }
                }

                if (lessonPlan.LessonPlanID == 0)
                    CollegeDBEntities.GetContext().LessonPlan.Add(lessonPlan);
                try
                {
                    CollegeDBEntities.GetContext().SaveChanges();
                    //currentTeacher.Teacher.CountOfHours += lessonPlan.Subject.Hours;
                    MessageBox.Show("Добавление пункта плана прошло успешно!");
                    NavigationManager.PlanFrame.Navigate(new PlanTeacherPage(currentTeacher));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.PlanFrame.Navigate(new PlanTeacherPage(currentTeacher));
        }
    }
}
