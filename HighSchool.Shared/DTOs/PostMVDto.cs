using System;
namespace HighSchool.Shared.DTOs
{
    public class PostMVDto
    {
        public PostDto? Post { get; set; }

        //public int? CategoryId { get; set; }

        public ICollection<CategoryDto>? Categories { get; set; }
    }
}

