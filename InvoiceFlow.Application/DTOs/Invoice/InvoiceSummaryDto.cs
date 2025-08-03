using InvoiceFlow.Application.DTOs.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.DTOs.Invoice
{
    public class InvoiceSummaryDto
    {
        public long ID { get; set; }    
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double TotalPrice { get; set; }
        public string CashierName { get; set; }
        public List<ItemCountDto> ItemCounts { get; set; }
    }

}
