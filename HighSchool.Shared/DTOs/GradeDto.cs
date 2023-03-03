using System;
namespace HighSchool.Shared.DTOs
{
    public class GradeDto:BaseEntityDto
    {
        public int GradeId { get; set; }
        public string? Name { get; set; }
        public string? Level { get; set; }
        public DateTime? Year { get; set; }
        public Guid StaffId { get; set; }
        public StaffDto? ClassTeacher { get; set; }
    }
}

