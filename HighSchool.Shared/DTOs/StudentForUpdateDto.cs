using System;
using Microsoft.VisualBasic;

namespace HighSchool.Shared.DTOs
{
    public class StudentForUpdateDto:PersonDto
    {
        public StudentForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }

        public ICollection<int>? GradesIds { get; set; }
        public ICollection<int>? GraduateIds { get; set; }
    }
}

