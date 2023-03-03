using System;
namespace HighSchool.Shared.DTOs
{
    public class GraduateForUpdateDto:BaseEntityDto
    {
      
        public DateTime? Year { get; set; }
        public int GradeId { get; set; }
    }
}

