using System;
namespace HighSchool.Entities.Models
{
    public class AllocatedResource:BaseEntity
    {
        public int AllocatedResourceId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public string? Status { get; set; }
        public DateTime? DateReturned { get; set; }
        public Student? Student { get; set; }
        public Guid StudentId { get; set; }
    }
}

