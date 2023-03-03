using System;
namespace HighSchool.Shared.DTOs
{
    public class GraduateDto
    {
        public int GraduateId { get; set; }
        public DateTime? Year { get; set; }
        public GradeDto? Grade { get; set; }
        public int GradeId { get; set; }
    }
}

