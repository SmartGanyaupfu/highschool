using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentSessionDto:BaseEntityDto
    {
        public int StudentSessionId { get; set; }
        public string? Name { get; set; }
    }
}

