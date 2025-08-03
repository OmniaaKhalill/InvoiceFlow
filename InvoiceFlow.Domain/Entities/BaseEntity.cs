using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Domain.Entities
{
    public class BaseEntity
    {
        public long ID { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
