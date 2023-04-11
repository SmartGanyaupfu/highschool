using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentSessionForCreationDto:BaseEntityDto
    {
        public StudentSessionForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
        public string? Name { get; set; }
    }
}

