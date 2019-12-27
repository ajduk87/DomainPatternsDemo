using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;

namespace CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities
{
    public class InvoiceCustomer : Entity
    {
        public Id InvoiceId { get; set; }
        public Id CustomerId { get; set; }
    }
}