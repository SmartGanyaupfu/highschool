using System;
using System.Linq.Expressions;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class InvoiceRepository : GenericRepositoryBase<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateInvoice(Guid studentId, Invoice invoice)
        {
            invoice.StudentId = studentId;
            Create(invoice);
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int invoiceId, bool trackChanges)
        {
            return await FindByCondition(i => i.InvoiceID.Equals(invoiceId), trackChanges).Include(ii=>ii.InvoiceItems).Include(s=>s.Student).FirstOrDefaultAsync();
        }

        public async Task<Invoice> GetInvoiceForStudentAsync(Guid studentId, int invoiceId, bool trackChanges)
        {
            return await FindByCondition(i => i.InvoiceID.Equals(invoiceId) && i.StudentId.Equals(studentId), trackChanges).Include(ii => ii.InvoiceItems).Include(s => s.Student).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Invoice>> GetInvoicesAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var invoices = await FindAll(trackChanges).Include(ii => ii.InvoiceItems).Include(s => s.Student).ToListAsync();

            return PagedList<Invoice>.ToPagedList(invoices, requestParameters.PageNumber, requestParameters.PageSize);
        }
    

        public void MoveToTrash(Invoice invoice)
        {
            invoice.DateUpdated = DateTime.Now;
            invoice.Deleted = true;
            Update(invoice);
        }

        public void PermanentDelete(Invoice invoice)
        {
            Delete(invoice);
        }

        public void UpdateInvoice(Invoice invoice)
        {
            Update(invoice);
        }
    }
}

