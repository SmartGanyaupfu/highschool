using System;
namespace HighSchool.Shared.DTOs
{
    public class LessonPlanDto:BaseEntityDto
    {
        public int LessonPlanId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public StaffDto? Teacher { get; set; }
        public Guid StaffId { get; set; }
        public DateTime? WeekEnding { get; set; }
    }
}

