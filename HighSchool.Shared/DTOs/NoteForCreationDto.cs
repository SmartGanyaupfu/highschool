﻿using System;
namespace HighSchool.Shared.DTOs
{
    public class NoteForCreationDto:BaseEntityDto
    {
        public NoteForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
     
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}

