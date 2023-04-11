using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentClassForCreationDto:BaseEntityDto
    {
        public StudentClassForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
   
        public string? Name { get; set; }
    }
}

