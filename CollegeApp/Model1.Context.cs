﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CollegeDBEntities : DbContext
    {
        public CollegeDBEntities()
            : base("name=CollegeDBEntities2")
        {
        }

        private static CollegeDBEntities context;
        public static CollegeDBEntities GetContext()
        {
            if (context == null)
                context = new CollegeDBEntities();
            return context;
        }

        public static string UserFullName;
        public static string UserRole;


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Classroom> Classroom { get; set; }
        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Gruppa> Gruppa { get; set; }
        public virtual DbSet<LessonNum> LessonNum { get; set; }
        public virtual DbSet<LessonPlan> LessonPlan { get; set; }
        public virtual DbSet<Otdel> Otdel { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Special> Special { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
