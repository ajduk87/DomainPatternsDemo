namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices
{
    public class InvoiceCustomerDto : Dto
    {
        public long CustomerId { get; set; }
        public long InvoiceId { get; set; }
    }
}