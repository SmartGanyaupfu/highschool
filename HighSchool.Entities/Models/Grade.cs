using System;
namespace HighSchool.Entities.Models
{
    public class Grade:BaseEntity
    {
        public int GradeId { get; set; }
        public string? Name { get; set; }
        public string? Level { get; set; }
        public DateTime? Year { get; set; }
        public Guid StaffId { get; set; }
        public Staff? ClassTeacher { get; set; }
        public ICollection<StudentGrade>? StudentGrades { get; set; }



    }
}

