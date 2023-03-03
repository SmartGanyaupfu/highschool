using System;
namespace HighSchool.Shared.DTOs
{
    public class LessonPlanForUpdateDto:BaseEntityDto
    {
        public LessonPlanForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }

        public string? Title { get; set; }
        public string? Content { get; set; }
        
        public DateTime? WeekEnding { get; set; }
    }
}

