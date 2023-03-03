using System;
namespace HighSchool.Shared.DTOs
{
    public class InvoiceForUpdateDto:BaseEntityDto
    {
        public InvoiceForUpdateDto()
        {
            DateUpdated = DateTime.Now;
        }
        public decimal? AmountPaid { get; set; }
     
        public string? Status { get; set; }
        public string? Term { get; set; }
       
        public string? InvoiceTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public ICollection<InvoiceItemForCreationDto>? InvoiceItems { get; set; }
    }
}

