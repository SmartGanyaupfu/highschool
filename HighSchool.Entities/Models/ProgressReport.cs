using System;
namespace HighSchool.Entities.Models
{
    public class ProgressReport:BaseEntity
    {
        public int ProgressReportId { get; set; }
        public DateTime? Year { get; set; }
        public string? Term { get; set; }
        public string? ClassTeacher  { get; set; }


    }
}

