using System;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Entities.Models
{
    [Index(nameof(SchoolYear.Year), IsUnique = true)]
    public class SchoolYear: BaseEntity
    {
        public int SchoolYearId { get; set; }

        
        public int Year { get; set; }
    }
}

