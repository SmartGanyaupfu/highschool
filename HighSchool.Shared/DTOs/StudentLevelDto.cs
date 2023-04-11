using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentLevelDto:BaseEntityDto
    {
        public int StudentLevelId { get; set; }
        public string? Name { get; set; }
    }
}

