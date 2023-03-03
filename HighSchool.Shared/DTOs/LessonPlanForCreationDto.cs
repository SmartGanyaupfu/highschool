using System;
namespace HighSchool.Shared.DTOs
{
    public class LessonPlanForCreationDto:BaseEntityDto
    {
        public LessonPlanForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
      
        public string? Title { get; set; }
        public string? Content { get; set; }
        
        public Guid StaffId { get; set; }
        public DateTime? WeekEnding { get; set; }
    }
}

