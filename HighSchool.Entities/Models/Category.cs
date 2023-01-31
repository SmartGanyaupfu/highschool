using System;
namespace HighSchool.Entities.Models
{
    public class Category:BaseEntity
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Slug { get; set; }

        public ICollection<PostCat> PostCats { get; set; }
    }
}

