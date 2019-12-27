namespace CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItem
{
    public class InvoiceItemCreateModel
    {
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public double DiscountBasic { get; set; }
        public long ActionId { get; set; }
    }
}