using System;
namespace HighSchool.Shared.DTOs
{
    public class GradeMVDto
    {
        public GradeDto? Grade { get; set; }


        public ICollection<StudentDto>? Students { get; set; }
    }
}

