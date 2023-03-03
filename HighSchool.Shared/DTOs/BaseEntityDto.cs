using System;
namespace HighSchool.Shared.DTOs
{
    public class BaseEntityDto
    {
        public DateTime? DateCreated { get; set; } 
        public DateTime? DateUpdated { get; set; } 
        public DateTime? DatePublished { get; set; }
        public bool? Deleted { get; set; } = false;
        public string? AuthorId { get; set; }
        public bool? Published { get; set; } = false;
    }
}

