using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Domain.Entities
{
    public class InvoiceDetail
    {
        public long ID { get; set; }
        public long InvoiceHeaderID { get; set; }
        public string ItemName { get; set; }
        public double ItemCount { get; set; }
        public double ItemPrice { get; set; }

        public InvoiceHeader InvoiceHeader { get; set; }
    }
}
