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
    public class CashierRepo : GenericRepo<Cashier>, ICashierRepo
    {
        private readonly AppDbContext _dbcontext;
        public CashierRepo(AppDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Cashier?> GetWithDetailsAsync(long id)

        {     return await _dbcontext.Cashiers
                .Include(c => c.Branch)
                .ThenInclude(b => b.City)
                .FirstOrDefaultAsync(c => c.ID == id && !c.IsDeleted);
        }

        


        public async Task<IReadOnlyList<Cashier>> GetAllWithDetailsAsync()
        {
            return await _dbcontext.Cashiers 
                .Include(i => i.Branch)
                .Where(i => i.IsDeleted == false)
                
                .ToListAsync();
        }
    }

}
