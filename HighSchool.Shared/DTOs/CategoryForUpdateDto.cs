using System;
namespace HighSchool.Shared.DTOs
{
    public class CategoryForUpdateDto
    {
        public string? Name { get; set; }
        public string? Slug { get; set; }
        public DateTime? DateUpdated { get; set; } = DateTime.Now;
        public string? AuthorId { get; set; }
    }
}

