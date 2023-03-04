using System;
namespace HighSchool.Shared.DTOs
{
    public class AllocatedResourceForCreationDto:BaseEntityDto
    {
        public AllocatedResourceForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public string? Status { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}

