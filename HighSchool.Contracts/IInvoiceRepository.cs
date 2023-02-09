using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IInvoiceRepository
    {
        Task<Invoice> GetInvoiceForStudentAsync(Guid studentId, int invoiceId, bool trackChanges);
        Task<Invoice> GetInvoiceByIdAsync(int invoiceId, bool trackChanges);
        Task<PagedList<Invoice>> GetInvoicesAsync(RequestParameters requestParameters, bool trackChanges);
        void CreateInvoice(Guid studentId, Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void MoveToTrash(Invoice invoice);
        void PermanentDelete(Invoice invoice);
    }
}

