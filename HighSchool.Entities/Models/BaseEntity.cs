﻿using System;
namespace HighSchool.Entities.Models
{
    public class BaseEntity
    {
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; } = DateTime.Now;
        public DateTime? DatePublished { get; set; }
        public bool? Deleted { get; set; } = false;
        public string? AuthorId { get; set; }
        public bool? Published { get; set; } = false;
    }
}

