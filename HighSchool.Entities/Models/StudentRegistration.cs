using System;
namespace HighSchool.Entities.Models
{
    public class StudentRegistration: BaseEntity
    {
        public int  StudentRegistrationId { get; set; }
        public int SchoolYearId { get; set; }
        public SchoolYear? SchoolYear { get; set; }
        public int StudentClassId { get; set; }
        public StudentClass? Class { get; set; }

        public int StudentSessionId { get; set; } //Morning Or Afternoon/ parallel
        public StudentSession? StudentSession { get; set; }
        public int SchoolTermId { get; set; }
        public SchoolTerm? SchoolTerm { get; set; }
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }

    }
}

