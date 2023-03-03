using System;
namespace HighSchool.Shared.DTOs
{
    public class StudentDto:PersonDto
    {
        public Guid StudentId { get; set; }

        public ICollection<AllocatedResourceDto>? AllocatedResources { get; set; }
        public ICollection<NoteDto>? Notes { get; set; }
        public ICollection<InvoiceDto>? Invoices { get; set; }
        public ICollection<CourseWorkReportDto>? CourseWorkReports { get; set; }
        public NextOfKinDto? NextOfKin { get; set; }

       
    }
}

