using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.DTOs.Cashier
{
    public class CashierUpdateDto
    {
        public long Id { get; set; }  
        public string CashierName { get; set; }
        public long BranchID { get; set; }
    }
}
