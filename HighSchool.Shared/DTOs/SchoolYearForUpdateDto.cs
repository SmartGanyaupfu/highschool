using System;
namespace HighSchool.Shared.DTOs
{
    public class SchoolYearForUpdateDto:BaseEntityDto
    {
        public SchoolYearForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }
       
        public int? Year { get; set; }
    }
}

