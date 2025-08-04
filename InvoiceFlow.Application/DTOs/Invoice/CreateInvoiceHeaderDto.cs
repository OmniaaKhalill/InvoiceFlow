using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.DTOs.Invoice
{
    public class CreateInvoiceHeaderDto
    {

        public string CustomerName { get; set; }
        public long? CashierID { get; set; }
        public long BranchID { get; set; }
        public List<CreateInvoiceDetailDto> items { get; set; }


    }
}
