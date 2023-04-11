using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentClassForUpdateDto:BaseEntityDto
    {
        public StudentClassForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }

        
        public string? Name { get; set; }
        public int StudentLevelId { get; set; }

    }
}

