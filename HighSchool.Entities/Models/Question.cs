using System;
namespace HighSchool.Entities.Models
{
    public class Question
    {

        public int QuestionId { get; set; }
        public string? Title { get; set; }

      
        public ICollection<Answer>? Answers { get; set; }
    }
}

