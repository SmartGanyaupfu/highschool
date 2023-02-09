using System;
namespace HighSchool.Entities.Models
{
    public class TeacherMV
    {
        public Staff? Staff { get; set; }

        //public int? CategoryId { get; set; }

        public ICollection<Course>? Courses { get; set; }
    }
}

