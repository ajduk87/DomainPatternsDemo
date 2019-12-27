using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices
{
    public class InvoiceCommercialistDto : Dto
    {
        public long InvoiceId { get; set; }
        public long CommercialistId { get; set; }
    }
}
