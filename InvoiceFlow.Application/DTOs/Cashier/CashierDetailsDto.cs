using InvoiceFlow.Application.DTOs.Branch;
using InvoiceFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Application.DTOs.Cashier
{
    public class CashierDetailsDto
    {
        public long CashierID { get; set; }
        public string CashierName { get; set; }
        public string BranchName { get; set; }

        public long BranchID { get; set; }
        public string CityName { get; set; }
    }
}
