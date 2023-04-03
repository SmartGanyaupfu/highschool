using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HighSchool.Entities;
using HighSchool.Entities.Models;
using HighSchool.Repository.SeedDataConfig;
using Image = HighSchool.Entities.Models.Image;

namespace HighSchool.Repository
{
    public class RepositoryContext: IdentityDbContext<User>
    {
        //Remember to install MS.Entityframworkcore
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostCat>()
           .HasKey(t => new { t.PostId, t.CategoryId });

            modelBuilder.Entity<PostCat>()
           .HasOne(pt => pt.Post)
           .WithMany(p => p.PostCats)
           .HasForeignKey(pt => pt.PostId)
           
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostCat>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.PostCats)
                .HasForeignKey(pt => pt.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<StaffCourse>()
         .HasKey(t => new { t.StaffId, t.CourseId });

            modelBuilder.Entity<StaffCourse>()
           .HasOne(pt => pt.Staff)
           .WithMany(p => p.StaffCourses)
           .HasForeignKey(pt => pt.StaffId)

           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StaffCourse>()
                .HasOne(pt => pt.Course)
                .WithMany(t => t.StaffCourses)
                .HasForeignKey(pt => pt.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

            /*modelBuilder.Entity<StudentGrade>()
      .HasKey(t => new { t.StudentId, t.GradeId });

            modelBuilder.Entity<StudentGrade>()
           .HasOne(pt => pt.Student)
           .WithMany(p => p.StudentGrades)
           .HasForeignKey(pt => pt.StudentId)

           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentGrade>()
                .HasOne(pt => pt.Grade)
                .WithMany(t => t.StudentGrades)
                .HasForeignKey(pt => pt.GradeId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentGraduate>()
   .HasKey(t => new { t.StudentId, t.GraduateId });

            modelBuilder.Entity<StudentGraduate>()
           .HasOne(pt => pt.Student)
           .WithMany(p => p.StudentGraduates)
           .HasForeignKey(pt => pt.StudentId)

           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentGraduate>()
                .HasOne(pt => pt.Graduate)
                .WithMany(t => t.StudentGraduates)
                .HasForeignKey(pt => pt.GraduateId)
            .OnDelete(DeleteBehavior.Cascade);*/


            // modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PageConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<ContentBlock> ContentBlocks { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<CourseWorkReport> CourseWorkReports { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LessonPlan> LessonPlans { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PhysicalAddress> PhysicalAddresses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Widget> Widgets { get; set; }
        public DbSet<AllocatedResource> AllocatedResources { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<FeeCategory> FeeCategories { get; set; }
        public DbSet<FeeCategoryAmount> FeeCategoryAmounts { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<SchoolTerm> SchoolTerms { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public DbSet<Graduate> Graduates { get; set; }
        public DbSet<StudentClass> StudentClasses { get; set; }
        public DbSet<StudentLevel> StudentLevels { get; set; }


        public DbSet<PostCat> PostCats { get; set; }
        public DbSet<StaffCourse> StffCourses { get; set; }

       // public DbSet<StudentGrade> StudentGrades { get; set; }
       // public DbSet<StudentGraduate> StudentGraduates { get; set; }


    }
}

