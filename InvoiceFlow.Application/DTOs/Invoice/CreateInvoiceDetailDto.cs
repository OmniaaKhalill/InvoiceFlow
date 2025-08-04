using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.DTOs.Invoice
{
    public class CreateInvoiceDetailDto
    {
        public long ItemID { get; set; }

        public int ItemCount { get; set; }

    }
}
