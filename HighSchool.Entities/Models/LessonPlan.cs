using System;
namespace HighSchool.Entities.Models
{
    public class LessonPlan
    {
        public int LessonPlanId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Staff? Teacher { get; set; }
        public Guid? StaffId { get; set; }
        public DateTime? WeekEnding { get; set; }
    }
}

