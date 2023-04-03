using System;
namespace HighSchool.Entities.Models
{
    public class Graduate:BaseEntity
    {
        
        public int GraduateId { get; set; }
        //public DateTime? Year { get; set; }
        public int SchoolYearId { get; set; }
        public SchoolYear? SchoolYear { get; set; }
        public int StudentClassId { get; set; }
        public StudentClass? Class { get; set; }
        public Guid StudentId { get; set; }
        public Student ? Student { get; set; }

        //public ICollection<StudentGraduate>? StudentGraduates { get; set; }

    }
}

