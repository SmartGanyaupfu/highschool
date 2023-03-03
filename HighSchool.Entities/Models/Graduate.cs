using System;
namespace HighSchool.Entities.Models
{
    public class Graduate:BaseEntity
    {
        
        public int GraduateId { get; set; }
        public DateTime? Year { get; set; }
        public Grade? Grade { get; set; }
        public int GradeId { get; set; }

        public ICollection<StudentGraduate>? StudentGraduates { get; set; }

    }
}

