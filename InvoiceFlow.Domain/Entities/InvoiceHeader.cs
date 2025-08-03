using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Domain.Entities
{
    public class InvoiceHeader : BaseEntity
    {

        public string CustomerName { get; set; }
        public DateTime Invoicedate { get; set; }
        public long? CashierID { get; set; }
        public long BranchID { get; set; }
        public double TotalPrice { get; set; } 

        public Cashier Cashier { get; set; }
        public Branch Branch { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
