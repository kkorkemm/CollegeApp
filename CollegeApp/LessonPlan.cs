//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollegeApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class LessonPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LessonPlan()
        {
            this.Schedule = new HashSet<Schedule>();
        }

        public string LessonPlanName => Gruppa.GruppaName + " -> " + Subject.SubjectName;

        public int LessonPlanID { get; set; }
        public int UserID { get; set; }
        public int SubjectID { get; set; }
        public int GruppaID { get; set; }
    
        public virtual Gruppa Gruppa { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedule { get; set; }
        public virtual LessonPlan LessonPlan1 { get; set; }
        public virtual LessonPlan LessonPlan2 { get; set; }
    }
}
