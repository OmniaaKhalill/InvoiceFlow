using InvoiceFlow.Application.DTOs.Invoice;
using InvoiceFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.Interfaces
{
    public interface ICashierRepo : IGenericRepo<Cashier>
    {

        Task<Cashier?> GetWithDetailsAsync(long id);
        Task<IReadOnlyList<Cashier>> GetAllWithDetailsAsync();
        Task<IReadOnlyList<Cashier>> GetAllByBranchAsync(long id);
    }
}
