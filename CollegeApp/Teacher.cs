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
    
    public partial class Teacher
    {
        public int UserID { get; set; }
        public int OtdelID { get; set; }
        public bool HasHighEducation { get; set; }
    
        public virtual Otdel Otdel { get; set; }
        public virtual User User { get; set; }
    }
}