using System;
namespace HighSchool.Entities.Models
{
    public class SchoolTerm: BaseEntity
    {
        public int SchoolTermId { get; set; }
        public string? Name { get; set; }
    }
}

