using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Models
{
    public class InvoiceItem
    {
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public double Value { get; set; }
    }
}
