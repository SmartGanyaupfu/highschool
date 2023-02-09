using System;
namespace HighSchool.Entities.Models
{
    public class StudentGrade
    {
        public int StudentGradeId { get; set; }

        public int GradeId { get; set; }
        public Grade? Grade { get; set; }

        public Guid StudentId { get; set; }
        public Student? Student { get; set; }
    }
}

