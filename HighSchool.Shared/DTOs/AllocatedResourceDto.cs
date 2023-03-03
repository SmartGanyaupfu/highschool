using System;
namespace HighSchool.Shared.DTOs
{
    public class AllocatedResourceDto
    {
        public int AllocatedResourceId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public string? Status { get; set; }
        public DateTime? DateReturned { get; set; }
        public StudentDto? Student { get; set; }
        public Guid StudentId { get; set; }
    }
}

