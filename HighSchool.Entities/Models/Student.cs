using System;

namespace HighSchool.Entities.Models
{
    public class Student:Person
    {
        public Guid StudentId { get; set; }
        public string? Class { get; set; }
        public ICollection<AllocatedResource>? AllocatedResources { get; set; }
        public ICollection<Note>? Notes { get; set; }
        public ICollection<Invoice> ? Invoices { get; set; }
        public ICollection<CourseWorkReport> ?CourseWorkReports { get; set; }
        public ICollection<ProgressReport>? ProgressReports { get; set; }
        public NextOfKin ? NextOfKin { get; set; }



    }
}


