using System;
namespace HighSchool.Shared.DTOs
{
    public class InvoiceForCreationDto:BaseEntityDto
    {
        public InvoiceForCreationDto()
        {
            DateCreated = DateTime.Now;
        }
       
        public decimal? AmountPaid { get; set; }
        public decimal? Balance { get; set; }
        public string? Status { get; set; }
        public string? Term { get; set; }
        public decimal? InvoiceTotal { get; set; }
        public string? InvoiceTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public ICollection<InvoiceItemForCreationDto>? InvoiceItems { get; set; }
       
        
    }
}

