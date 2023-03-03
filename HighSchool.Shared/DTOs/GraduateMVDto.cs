using System;
namespace HighSchool.Shared.DTOs
{
    public class GraduateMVDto
    {
        public GraduateDto? Graduate { get; set; }


        public ICollection<StudentDto>? Students { get; set; }
    }
}

