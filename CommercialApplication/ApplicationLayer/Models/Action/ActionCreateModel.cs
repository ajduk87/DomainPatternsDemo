namespace CommercialApplicationCommand.ApplicationLayer.Models.Action
{
    public class ActionCreateModel
    {
        public long ProductId { get; set; }
        public double Discount { get; set; }
        public int ThresholdAmount { get; set; }
        public long CustomerId { get; set; }
    }
}