using System;
namespace HighSchool.Shared.DTOs
{
    public class PostForUpdateDto
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? FeatureImageId { get; set; }
        public DateTime? DateUpdated { get; set; } = DateTime.Now;
        public string? AuthorId { get; set; }

        public ICollection<int>? CategoryIds { get; set; }
    }
}

