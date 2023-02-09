using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class PaymentRepository : GenericRepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreatePayment(int invoiceId, Payment payment)
        {
            payment.InvoiceID = invoiceId;
            Create(payment);
        }

        public async Task<Payment> GetPaymentByIdAsync(int paymentId, bool trackChanges)
        {
            return await FindByCondition(p => p.PaymentID.Equals(paymentId),
              trackChanges).Include(i => i.Invoice).ThenInclude(s => s.Student).SingleOrDefaultAsync();
        }

        public async Task<Payment> GetPaymentForInvoiceAsync(int invoiceId, int paymentId, bool trackChanges)
        {
            return await FindByCondition(p => p.PaymentID.Equals(paymentId) && p.InvoiceID.Equals(invoiceId),
              trackChanges).Include(i => i.Invoice).ThenInclude(p => p.Student).SingleOrDefaultAsync();
        }

        public async Task<PagedList<Payment>> GetPaymentsAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var payments = await FindAll(trackChanges).ToListAsync();

            return PagedList<Payment>.ToPagedList(payments, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<IEnumerable<Payment>> PaymentCountAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public void UpdatePayment(Payment payment)
        {
            Update(payment);
        }
    }
}

