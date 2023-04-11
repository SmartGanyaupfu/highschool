using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentRegistrationDto:BaseEntityDto
    {
        public int StudentRegistrationId { get; set; }
        public int SchoolYearId { get; set; }
        public SchoolYearDto? SchoolYear { get; set; }
        public int StudentClassId { get; set; }
        public StudentClassDto? StudentClass { get; set; }
        public int StudentLevelId { get; set; }
        public StudentLevelDto? StudentLevel { get; set; }

        public int StudentSessionId { get; set; } //Morning Or Afternoon/ parallel
        public StudentSessionDto? StudentSession { get; set; }
        public int SchoolTermId { get; set; }
        public SchoolTermDto? SchoolTerm { get; set; }
        public Guid StudentId { get; set; }
        public StudentDto? Student { get; set; }
    }
}

