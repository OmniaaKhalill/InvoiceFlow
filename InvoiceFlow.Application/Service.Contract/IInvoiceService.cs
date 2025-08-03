using InvoiceFlow.Application.DTOs.Invoice;
using InvoiceFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.Service.Contract
{
    public interface IInvoiceService
    {
        Task<InvoiceHeader?> CreateInvoiceAsync(CreateInvoiceHeaderDto dto);
    }

}
