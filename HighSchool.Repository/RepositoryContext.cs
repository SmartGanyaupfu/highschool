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


            // modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PageConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());

        }
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
        public DbSet<ProgressReport> ProgressReports { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Widget> Widgets { get; set; }
        public DbSet<AllocatedResource> AllocatedResources { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }


    }
}

