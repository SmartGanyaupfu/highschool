using System;
namespace HighSchool.Shared.DTOs
{
    public class CourseDto:BaseEntityDto
    {
        public Guid CourseId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? FeatureImageId { get; set; }
        public string? Level { get; set; }
        public string? Prerequisite { get; set; }
        public string? Curriculum { get; set; }
        public string? CareerOpportunites { get; set; }
        public string? Duration { get; set; }
        public string? Faculty { get; set; }
        public ImageDto? Image { get; set; }
    }
}

