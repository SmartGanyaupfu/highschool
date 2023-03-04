using System;
namespace HighSchool.Shared.DTOs
{
    public class ContentBlockForUpdateDto:BaseEntityDto
    {
        
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}

