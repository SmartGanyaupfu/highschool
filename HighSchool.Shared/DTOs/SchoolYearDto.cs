using System;
namespace HighSchool.Shared.DTOs
{
    public class SchoolYearDto:BaseEntityDto
    {
        public int SchoolYearId { get; set; }
        public int? Year { get; set; }
    }
}

