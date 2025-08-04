using InvoiceFlow.Application.DTOs.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.DTOs.Invoice
{
    public class InvoiceDetailsDto
    {
        public long ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double TotalPrice { get; set; }
        public long? CashierID { get; set; }
        public string CashierName { get; set; }
        public long BranchID { get; set; }

        public string BranchName { get; set; }
        public List< ItemInvoiceDto> Items { get; set; }
    }
}
