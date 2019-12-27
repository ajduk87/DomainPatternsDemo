namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.OrderItemOrder
{
    public class OrderId
    {
        public long Content { get; set; }

        public OrderId(long Content)
        {
            this.Content = Content;
        }

        public static explicit operator OrderId(long orderId)
        {
            return new OrderId(orderId);
        }

        public static implicit operator long(OrderId orderId)
        {
            return orderId.Content;
        }
    }
}