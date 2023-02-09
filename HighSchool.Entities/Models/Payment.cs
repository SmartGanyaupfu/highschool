using System;
namespace HighSchool.Entities.Models
{
    public class Payment:BaseEntity
    {
        public int PaymentID { get; set; }
        public DateTime? Date { get; set; }
        public decimal? AmountPaid { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Note { get; set; }
        public int InvoiceID { get; set; }
        public Invoice? Invoice { get; set; }
    }
}

