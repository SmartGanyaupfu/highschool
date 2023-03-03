using System;
namespace HighSchool.Entities.Models
{
    public class Question:BaseEntity
    {

        public int QuestionId { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public String? Description { get; set; }

        // Remember to run a migration for these changes below
        public int  GradeId { get; set; }

        public Guid CourseId { get; set; }


        public ICollection<Answer>? Answers { get; set; }
    }
}

