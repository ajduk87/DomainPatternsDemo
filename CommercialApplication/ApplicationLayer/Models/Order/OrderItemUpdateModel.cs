namespace CommercialApplication.ApplicationLayer.Models.Order
{
    public class OrderItemUpdateModel : OrderItemCreateModel
    {
        public long Id { get; set; }
        public bool IsChanged { get; set; }
    }
}