using System;
namespace HighSchool.Entities.Models
{
    public class StudentMV
    {
        public Student? Student { get; set; }


        public ICollection<StudentClass>? Grades { get; set; }
        public ICollection<Graduate>? Graduations { get; set; }
    }
}

