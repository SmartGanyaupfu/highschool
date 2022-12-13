using System;
namespace HighSchool.Entities.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string? Option { get; set; }
        public bool? CorrectAnswer { get; set; }
        public string? Explantion{ get; set; }

        public Question? Question { get; set; }
        public int? QuestionId { get; set; }
    }
}

