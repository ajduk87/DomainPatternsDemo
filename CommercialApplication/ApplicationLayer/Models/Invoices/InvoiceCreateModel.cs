using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItem;
using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Models.Invoices
{
    public class InvoiceCreateModel
    {
        public long SellingProgramId { get; set; }
        public long CustomerId { get; set; }
        public long CommercialistId { get; set; }
        public IEnumerable<InvoiceItemCreateModel> InvoiceItems { get; set; }
    }
}