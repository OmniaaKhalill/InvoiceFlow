using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Infrastructure.Repositories
{
    public class ItemRepo : GenericRepo<Item>, IItemRepo
    {
        public ItemRepo(AppDbContext dbcontext) : base(dbcontext)
        {
        }

       
    }
}
