using System;
using HighSchool.Entities.Models;
using HighSchool.Shared.RequestFeatures;

namespace HighSchool.Contracts
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentForInvoiceAsync(int invoiceId, int paymentId, bool trackChanges);
        Task<Payment> GetPaymentByIdAsync(int paymentId, bool trackChanges);
        Task<PagedList<Payment>> GetPaymentsAsync(RequestParameters requestParameters, bool trackChanges);
        void CreatePayment(int invoiceId, Payment payment);
        void UpdatePayment(Payment payment);
       
        Task<IEnumerable<Payment>> PaymentCountAsync(bool trackChanges);
    }
}

