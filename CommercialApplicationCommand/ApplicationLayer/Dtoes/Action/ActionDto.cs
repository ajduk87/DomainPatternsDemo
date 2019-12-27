namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Action
{
    public class ActionDto : Dto
    {
        public long ProductId { get; set; }
        public double Discount { get; set; }
        public int ThresholdAmount { get; set; }
        public long CustomerId { get; set; }
        public long SalesChannelId { get; set; }
    }
}