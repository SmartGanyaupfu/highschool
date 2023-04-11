using System;
using Microsoft.VisualBasic;

namespace HighSchool.Shared.DTOs
{
    public class SchoolTermForUpdateDto:BaseEntityDto
    {
        public SchoolTermForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }
        
        public string? Name { get; set; }
    }
}

