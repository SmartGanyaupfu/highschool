using System;
namespace HighSchool.Shared.DTOs
{
    public class SchoolTermDto:BaseEntityDto
    {
        public int SchoolTermId { get; set; }
        public string? Name { get; set; }
    }
}

