using System;
namespace HighSchool.Shared.DTOs
{
    public class ContentBlockForCreationDto:BaseEntityDto
    {
        public ContentBlockForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}

