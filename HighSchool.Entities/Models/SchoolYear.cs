using System;
namespace HighSchool.Entities.Models
{
    public class SchoolYear: BaseEntity
    {
        public int SchoolYearId { get; set; }
        public DateTime? Year { get; set; }
    }
}

