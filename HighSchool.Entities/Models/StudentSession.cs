using System;
namespace HighSchool.Entities.Models
{
    public class StudentSession: BaseEntity
    {
        public int StudentSessionId { get; set; }
        public string? Name { get; set; }
    }
}

