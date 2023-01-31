﻿using System;
namespace HighSchool.Entities.Models
{
    public class Post:BaseEntity
    {
        public Guid PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? FeatureImageId { get; set; }

        //public int? CategoryId { get; set; }

        public ICollection<PostCat> PostCats { get; set; }

    }
}

