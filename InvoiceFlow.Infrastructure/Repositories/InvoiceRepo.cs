using InvoiceFlow.Application.DTOs.Invoice;
using InvoiceFlow.Application.DTOs.Item;
using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Infrastructure.Repositories
{
    public class InvoiceRepo : GenericRepo<InvoiceHeader>, IInvoiceRepo
    {
        private readonly AppDbContext _dbcontext;
        public InvoiceRepo(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<InvoiceHeader?> GetWithDetailsAsync(long id)
        {
            return await _dbcontext.InvoiceHeaders
                .Include(i => i.InvoiceDetails)
                .Include(i => i.Cashier)
                .Include(i => i.Branch)
                    .ThenInclude(b => b.City)
                .FirstOrDefaultAsync(i => i.ID == id && !i.IsDeleted);
        }


        public async Task<IReadOnlyList<InvoiceSummaryDto>> GetAllWithDetailsAsync()
        {
            return await _dbcontext.InvoiceHeaders
                .Where(i => i.IsDeleted == false)
                .Select(i => new InvoiceSummaryDto
                {
                    ID = i.ID,
                    CustomerName = i.CustomerName,
                    InvoiceDate = i.Invoicedate,
                    TotalPrice = i.TotalPrice,
                    CashierName = i.Cashier.CashierName,
                    ItemCounts = i.InvoiceDetails
                        .Where(d => d.IsDeleted == false)
                        .Select(d => new ItemCountDto
                        {
                            ItemID = d.ID,
                            ItemName = d.Item.Name,
                            ItemCount = d.ItemCount
                        }).ToList()
                })
                .ToListAsync();
        }

    }

}
