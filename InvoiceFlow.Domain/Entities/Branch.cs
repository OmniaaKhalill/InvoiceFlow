using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Domain.Entities
{
    public class Branch : BaseEntity
    {
        
        public string BranchName { get; set; }
        public long CityID { get; set; }
        public City City { get; set; }
        public ICollection<Cashier> Cashiers { get; set; }
        public ICollection<InvoiceHeader> InvoiceHeaders { get; set; }
    }
}
