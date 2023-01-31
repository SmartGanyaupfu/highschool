using System;
namespace HighSchool.Entities.Models
{
    public class ContentBlock:BaseEntity
    {
        public int ContentBlockId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}

