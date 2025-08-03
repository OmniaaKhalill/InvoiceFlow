using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.DTOs.Item
{
    public class ItemCountDto
    {
        public long ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemCount { get; set; }
    }

}
