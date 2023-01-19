using System;
namespace HighSchool.Entities.Models
{
    public class PostMV 
    {
        public Post? Post { get; set; }

        //public int? CategoryId { get; set; }

        public ICollection< Category>? Categories { get; set; }

    }
}

