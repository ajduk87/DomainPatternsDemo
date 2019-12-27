namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.InvoiceItemInvoice
{
    public class InvoiceItemId : ValueObject
    {
        public long Content { get; set; }

        public InvoiceItemId(long Content)
        {
            this.Content = Content;
        }

        public static explicit operator InvoiceItemId(long invoiceItemId)
        {
            return new InvoiceItemId(invoiceItemId);
        }

        public static implicit operator long(InvoiceItemId invoiceItemId)
        {
            return invoiceItemId.Content;
        }
    }
}