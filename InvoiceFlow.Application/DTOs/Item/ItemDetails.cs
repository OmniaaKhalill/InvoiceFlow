using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.DTOs.Item
{
    public class ItemDetails
    {
        public long ItemID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; } = 0;
    }
}
