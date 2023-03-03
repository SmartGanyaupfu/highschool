using System;
namespace HighSchool.Shared.DTOs
{
    public class NoteForCreationDto:BaseEntityDto
    {
        public NoteForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
        public int NoteId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
     
        public Guid StudentId { get; set; }
    }
}

