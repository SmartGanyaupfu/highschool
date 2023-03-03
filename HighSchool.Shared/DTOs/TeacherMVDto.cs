using System;
namespace HighSchool.Shared.DTOs
{
    public class TeacherMVDto
    {
        public StaffDto? Staff { get; set; }

        //public int? CategoryId { get; set; }

        public ICollection<CourseDto>? Courses { get; set; }
    }
}

