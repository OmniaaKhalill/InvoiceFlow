using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Domain.Entities
{
    public class Item:BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
