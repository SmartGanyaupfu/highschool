using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentForCreationDto:PersonDto
    {
        public StudentForCreationDto()
        {
            DateCreated = DateTime.Now;
        }

        public ICollection<int>? GradesIds { get; set; }
        public ICollection<int>? GraduateIds { get; set; }
    }
}

