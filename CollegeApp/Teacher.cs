//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Linq;

namespace CollegeApp
{
    public partial class Teacher
    {
        public int UserID { get; set; }
        public int OtdelID { get; set; }
        public bool HasHighEducation { get; set; }

        public string HighEducation => HasHighEducation ? "Есть" : "Нет";

        public int CountOfPlan => CollegeDBEntities.GetContext().LessonPlan.Where(p => p.UserID == UserID).Count();
        public int CountOfHours { get; set; }
        public virtual Otdel Otdel { get; set; }
        public virtual User User { get; set; }
    }
}
