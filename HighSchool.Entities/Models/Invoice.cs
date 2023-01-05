using System;
namespace HighSchool.Entities.Models
{
    public class Invoice: BaseEntity
    {
        public int InvoiceID { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Balance { get; set; }
        public string? Status { get; set; }
        public string? Term { get; set; }
        public decimal? InvoiceTotal { get; set; }
        public string ?InvoiceTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public ICollection<InvoiceItem> ?InvoiceItems { get; set; }
        public Guid? StudentId { get; set; }
        public Student? Student { get; set; }
    }
}

