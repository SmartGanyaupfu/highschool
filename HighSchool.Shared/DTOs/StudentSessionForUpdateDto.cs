using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentSessionForUpdateDto:BaseEntityDto
    {
        public StudentSessionForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }
        public string? Name { get; set; }
    }
}

