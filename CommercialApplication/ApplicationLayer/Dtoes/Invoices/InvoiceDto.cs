namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices
{
    public class InvoiceDto : Dto
    {
        public long SellingProgramId { get; set; }
        public long CustomerId { get; set; }
        public long CommercialistId { get; set; }
        public InvoiceItemDto[] InvoiceItems { get; set; }
    }
}