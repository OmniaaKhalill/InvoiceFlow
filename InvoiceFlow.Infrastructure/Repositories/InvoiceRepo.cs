using InvoiceFlow.Application.Interfaces;
using InvoiceFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Infrastructure.Repositories
{
    public class InvoiceRepo : GenericRepo<InvoiceHeader>, IInvoiceRepo
    {
        public InvoiceRepo(AppDbContext dbcontext) : base(dbcontext)
        {
        }
    }

}
