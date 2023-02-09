using System;
namespace HighSchool.Entities.Models
{
    public class Note :BaseEntity
    {
        public int NoteId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Student? Student { get; set; }
        public Guid StudentId { get; set; }

    }
}

