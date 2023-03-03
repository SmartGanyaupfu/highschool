using System;
namespace HighSchool.Shared.DTOs
{
    public class CourseMVDto
    {
        public CourseDto? Course { get; set; }

        //public int? CategoryId { get; set; }

        public ICollection<StaffDto>? Staff { get; set; }
    }
}

