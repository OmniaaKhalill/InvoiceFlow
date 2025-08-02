using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Domain.Entities
{
    public class InvoiceHeader
    {
        public long ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime Invoicedate { get; set; }
        public int? CashierID { get; set; }
        public int BranchID { get; set; }

        public Cashier Cashier { get; set; }
        public Branch Branch { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
