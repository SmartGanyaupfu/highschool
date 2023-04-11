using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentLevelForCreationDto:BaseEntityDto
    {
        public StudentLevelForCreationDto()
        {
            DateCreated = DateTime.Now;
        }

        
        public string? Name { get; set; }
    }
}

