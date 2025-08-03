using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Domain.Entities
{
    public class InvoiceDetail : BaseEntity
    {

        public long InvoiceHeaderID { get; set; }
        public long ItemID { get; set; }
        public int ItemCount { get; set; }

        public InvoiceHeader InvoiceHeader { get; set; }
        public Item Item { get; set; }
    }

}
