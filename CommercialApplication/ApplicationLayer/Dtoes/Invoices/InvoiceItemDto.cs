namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices
{
    public class InvoiceItemDto : Dto
    {
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public int RealAmount { get; set; }
        public double DiscountBasic { get; set; }
        public long ActionId { get; set; }
    }
}