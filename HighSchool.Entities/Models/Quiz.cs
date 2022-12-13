using System;
namespace HighSchool.Entities.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }

        public string? Title { get; set; }

        public ICollection<Question>? Questions { get; set; }
    }
}


