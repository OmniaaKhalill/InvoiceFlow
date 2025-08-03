using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.DTOs.Cashier
{
    public class CashierCreateDto
    {
        public string CashierName { get; set; }
        public long BranchID { get; set; }
    }
}
