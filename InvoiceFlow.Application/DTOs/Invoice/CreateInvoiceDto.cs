using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.DTOs.Invoice
{
    public class CreateInvoiceDto
    {
       
            public string CustomerName { get; set; }
            public DateTime Invoicedate { get; set; }
            public long? CashierID { get; set; }
            public long BranchID { get; set; }

           // public List<CreateInvoiceItemDto> InvoiceDetails { get; set; }
        

    }
}
