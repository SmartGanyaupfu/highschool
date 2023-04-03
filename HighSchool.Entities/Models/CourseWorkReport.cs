using System;
namespace HighSchool.Entities.Models
{
    public class CourseWorkReport:BaseEntity
    {
        public int CourseWorkReportId { get; set; }
        public DateTime? Year { get; set; }
        public string? Term { get; set; }

        public int? PossibleMark { get; set; }
        public int? MarkObtained { get; set; }
        public string? Comments { get; set; }

        public Student? Student { get; set; }
        public Guid StudentId { get; set; }

        public int StudentClassId { get; set; }
        public StudentClass? Class { get; set; }

        public Course? Course  { get; set; }
        public Guid CourseId { get; set; }
    }
}

