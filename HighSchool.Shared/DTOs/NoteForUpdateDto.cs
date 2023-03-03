using System;
namespace HighSchool.Shared.DTOs
{
    public class NoteForUpdateDto:BaseEntityDto
    {
        public NoteForUpdateDto()
        {
            DateCreated = DateTime.Now;
        }
       
        public string? Title { get; set; }
        public string? Content { get; set; }
       
    }
}

