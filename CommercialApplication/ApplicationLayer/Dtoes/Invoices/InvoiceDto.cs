using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices
{
    public class InvoiceDto : Dto
    {
        public long SellingProgramId { get; set; }
        public long CustomerId { get; set; }
        public long OrderId { get; set; }
        public IEnumerable<InvoiceItemDto> InvoiceItems { get; set; }
    }
}