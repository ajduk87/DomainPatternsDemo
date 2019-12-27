namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.InvoiceItemInvoice
{
    public class InvoiceId : ValueObject
    {
        public long Content { get; set; }

        public InvoiceId(long Content)
        {
            this.Content = Content;
        }

        public static explicit operator InvoiceId(long invoiceId)
        {
            return new InvoiceId(invoiceId);
        }

        public static implicit operator long(InvoiceId invoiceId)
        {
            return invoiceId.Content;
        }
    }
}