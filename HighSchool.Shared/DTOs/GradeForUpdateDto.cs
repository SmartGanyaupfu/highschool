using System;
namespace HighSchool.Shared.DTOs
{
    public class GradeForUpdateDto:BaseEntityDto
    {
        public GradeForUpdateDto()
        {
            DateUpdated = DateTime.Now;

        }
     
        public string? Name { get; set; }
        public string? Level { get; set; }
        public DateTime? Year { get; set; }
        public Guid StaffId { get; set; }
    }
}

