namespace CommercialApplicationCommand.ApplicationLayer.Models.Order
{
    public abstract class OrderModelBase
    {
        public long CustomerId { get; set; }
        public long CommercialistId { get; set; }
    }
}