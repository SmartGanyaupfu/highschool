using System;
namespace HighSchool.Shared.DTOs
{
    public class InvoiceItemDto
    {
        public int InvoiceItemID { get; set; }
        public string? Item { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnityPrice { get; set; }

        public decimal? Total { get; set; }

        public int InvoiceID { get; set; }
    }
}

