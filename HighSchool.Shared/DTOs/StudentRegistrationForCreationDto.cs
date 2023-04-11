using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentRegistrationForCreationDto:BaseEntityDto
    {
        public StudentRegistrationForCreationDto()
        {
            DateCreated = DateTime.Now;
        }

        public int SchoolYearId { get; set; }
        public int StudentClassId { get; set; }
        public int StudentLevelId { get; set; }

        public int StudentSessionId { get; set; } 
        public int SchoolTermId { get; set; }
        public Guid StudentId { get; set; }
    }
}

