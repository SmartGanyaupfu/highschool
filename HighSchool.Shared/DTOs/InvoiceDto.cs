using System;
namespace HighSchool.Shared.DTOs
{
    public class InvoiceDto:BaseEntityDto
    {
        public int InvoiceID { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Balance { get; set; }
        public string? Status { get; set; }
        public string? Term { get; set; }
        public decimal? InvoiceTotal { get; set; }
        public string? InvoiceTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public ICollection<InvoiceItemDto>? InvoiceItems { get; set; }
        public Guid StudentId { get; set; }
        public StudentDto? Student { get; set; }
    }
}

