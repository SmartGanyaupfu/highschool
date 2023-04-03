using System;
namespace HighSchool.Entities.Models
{
    public class StudentClass:BaseEntity
    {
        public int StudentClassId { get; set; }
        public string? Name { get; set; }
        public int StudentLevelId { get; set; }
        public StudentLevel? StudentLevel { get; set; }
        // public string? Level { get; set; }
        //  public DateTime? Year { get; set; }
        // public Guid StaffId { get; set; }
        // public Staff? ClassTeacher { get; set; }
        // public ICollection<StudentGrade>? StudentGrades { get; set; }



    }
}

