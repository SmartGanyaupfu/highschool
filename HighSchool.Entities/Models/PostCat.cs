using System;
namespace HighSchool.Entities.Models
{
    public class PostCat
    {
        public int PostCatId { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid  PostId { get; set; }
        public Post  Post { get; set; }

    }
}

