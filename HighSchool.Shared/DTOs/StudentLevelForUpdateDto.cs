using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentLevelForUpdateDto:BaseEntityDto
    {
        public StudentLevelForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }

        
        public string? Name { get; set; }
    }
}

