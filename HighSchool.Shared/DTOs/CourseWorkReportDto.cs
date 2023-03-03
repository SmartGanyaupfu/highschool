using System;
namespace HighSchool.Shared.DTOs
{
    public class CourseWorkReportDto:BaseEntityDto
    {
        public int CourseWorkReportId { get; set; }
        public DateTime? Year { get; set; }
        public string? Term { get; set; }

        public int? PossibleMark { get; set; }
        public int? MarkObtained { get; set; }
        public string? Comments { get; set; }

        public StudentDto? Student { get; set; }
        public Guid StudentId { get; set; }

        public GradeDto? Class { get; set; }
        public int GradeId { get; set; }

        public CourseDto? Course { get; set; }
        public Guid CourseId { get; set; }
    }
}

