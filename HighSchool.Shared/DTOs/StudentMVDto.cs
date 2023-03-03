using System;
using System.Diagnostics;

namespace HighSchool.Shared.DTOs
{
    public class StudentMVDto
    {
        public StudentDto? Student { get; set; }


        public ICollection<GradeDto>? Grades { get; set; }
        public ICollection<GraduateDto>? Graduations { get; set; }
    }
}

