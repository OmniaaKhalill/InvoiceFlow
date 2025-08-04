using InvoiceFlow.Application.Repository.Contract;
using InvoiceFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Infrastructure.Repositories
{
    public class BranchRepo : GenericRepo<Branch>, IBranchRepo
    {
        public BranchRepo(AppDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
