using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentClassDto:BaseEntityDto
    {
        public int StudentClassId { get; set; }
        public string? Name { get; set; }
        public int StudentLevelId { get; set; }
        public StudentLevelDto? StudentLevel { get; set; }
    }
}

