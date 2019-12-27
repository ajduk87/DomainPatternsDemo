using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.InvoiceItemInvoice;

namespace CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities
{
    public class InvoiceItemInvoice : Entity
    {
        public InvoiceId InvoiceId { get; set; }
        public InvoiceItemId InvoiceItemId { get; set; }
    }
}