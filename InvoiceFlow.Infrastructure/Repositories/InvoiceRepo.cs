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

        public async Task<InvoiceDetailsDto?> GetWithDetailsAsync(long id)
        {
            return await _dbcontext.InvoiceHeaders
                .Where(i => i.ID == id && !i.IsDeleted)
                .Select(i => new InvoiceDetailsDto
                {
                    ID = i.ID,
                    CustomerName = i.CustomerName,
                    InvoiceDate = i.Invoicedate,
                    TotalPrice = i.TotalPrice,
                    CashierID = i.CashierID,
                    CashierName = i.Cashier.CashierName,
                    BranchID = i.BranchID,
                    BranchName = i.Branch.BranchName,
                    Items = i.InvoiceDetails.Select(d => new ItemInvoiceDto
                    {
                        Id = d.ItemID,
                        Name = d.Item.Name,
                        Price = d.Item.Price,
                        Count =d.ItemCount
                    }).ToList()
                })
                .FirstOrDefaultAsync();
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
                    BranchName = i.Branch.BranchName,
                    CashierName = i.Cashier.CashierName,
                    ItemsCount = i.InvoiceDetails
                        .Where(d => d.IsDeleted == false).Count()

                }).ToListAsync();

        }

    }

}