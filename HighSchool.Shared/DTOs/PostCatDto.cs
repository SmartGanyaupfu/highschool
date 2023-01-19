using System;
namespace HighSchool.Shared.DTOs
{
    public class PostCatDto
    {
        public int PostCatId { get; set; }

        public int? CategoryId { get; set; }
        public CategoryDto? Category { get; set; }

        public Guid? PostId { get; set; }
        public PostDto? Post { get; set; }
    }
}

