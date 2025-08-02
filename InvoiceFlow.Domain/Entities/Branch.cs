using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Domain.Entities
{
    public class Branch
    {
        public int ID { get; set; }
        public string BranchName { get; set; }
        public int CityID { get; set; }

        public City City { get; set; }
        public ICollection<Cashier> Cashiers { get; set; }
        public ICollection<InvoiceHeader> InvoiceHeaders { get; set; }
    }
}
