using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.ApplicationLayer.Models.Invoices
{
    public class InvoiceViewModel
    {
        public long SellingProgramId { get; set; }
        public long CustomerId { get; set; }
        public long OrderId { get; set; }
        public IEnumerable<InvoiceItemCreateModel> InvoiceItems { get; set; }
    }
}
