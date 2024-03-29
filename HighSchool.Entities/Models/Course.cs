﻿using System;

namespace HighSchool.Entities.Models
{
    public class Course:BaseEntity
    {
        public Guid CourseId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Excerpt { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeyWords { get; set; }
        public string? Slug { get; set; }
        public int? FeatureImageId { get; set; }
        public int? StudentLevelId { get; set; }
        public StudentLevel? StuentLevel { get; set; }
        public string? Prerequisite { get; set; }
        public string? Curriculum { get; set; }
        public string? CareerOpportunites { get; set; }
        public string? Duration { get; set; }
        public string? Faculty { get; set; }
        public ICollection<StaffCourse>? StaffCourses { get; set; }
    }
}

