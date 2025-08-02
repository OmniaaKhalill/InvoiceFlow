using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceFlow.Domain.Entities
{
    public class City
    {
        public int ID { get; set; }
        public string CityName { get; set; }

        public ICollection<Branch> Branches { get; set; }
    }
}
