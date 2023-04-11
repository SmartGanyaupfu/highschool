using System;
namespace HighSchool.Shared.DTOs
{
    public class SchoolYearForCreationDto:BaseEntityDto
    {
        public SchoolYearForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
        
        public int? Year { get; set; }
    }
}

