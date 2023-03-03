using System;
namespace HighSchool.Entities.Models
{
    public class Staff:Person
    {
        public Guid StaffId { get; set; }
        public string? JobTitle { get; set; }
        public string? Employer { get; set; }
        public string? MaritalStatus { get; set; }
       
        public int EmployeeTypeId { get; set; }
        public EmployeeType? EmployeeType { get; set; }
        public ICollection<LessonPlan>? LessonPlans { get; set; }
        public ICollection<StaffCourse>? StaffCourses { get; set; }


    }
}

