using System;
namespace HighSchool.Shared.DTOs
{
    public class CourseWorkReportForUpdateDto:BaseEntityDto
    {
        public CourseWorkReportForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }
        public DateTime? Year { get; set; }
        public string? Term { get; set; }

        public int? PossibleMark { get; set; }
        public int? MarkObtained { get; set; }
        public string? Comments { get; set; }
    }
}

