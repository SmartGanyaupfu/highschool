using System;
namespace HighSchool.Entities.Models
{
    public class Question:BaseEntity
    {

        public int QuestionId { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public String? Description { get; set; }


        public ICollection<Answer>? Answers { get; set; }
    }
}

