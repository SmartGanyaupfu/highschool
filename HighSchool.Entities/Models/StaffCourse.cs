using System;
namespace HighSchool.Entities.Models
{
    public class StaffCourse
    {
        public int StaffCourseId { get; set; }

        public Guid CourseId { get; set; }
        public Course? Course { get; set; }

        public Guid StaffId { get; set; }
        public Staff? Staff { get; set; }
    }
}

