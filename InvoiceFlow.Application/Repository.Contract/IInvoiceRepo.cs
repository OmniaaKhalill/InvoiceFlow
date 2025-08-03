using InvoiceFlow.Application.DTOs.Invoice;
using InvoiceFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.Interfaces
{
    public interface IInvoiceRepo : IGenericRepo<InvoiceHeader>
    {
        Task<InvoiceHeader?> GetWithDetailsAsync(long id);
        Task<IReadOnlyList<InvoiceSummaryDto>> GetAllWithDetailsAsync();
    }

}
