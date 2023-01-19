using System;
namespace HighSchool.Shared.DTOs
{
    public class PostDto:BaseEntityDto
    {
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? FeatureImageId { get; set; }
        public ImageDto? Image { get; set; }
        public ICollection<PostCatDto>? PostCats { get; set; }

    }
}

