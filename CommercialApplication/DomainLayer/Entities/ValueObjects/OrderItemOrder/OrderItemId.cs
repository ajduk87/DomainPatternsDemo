namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.OrderItemOrder
{
    public class OrderItemId
    {
        public long Content { get; set; }

        public OrderItemId(long Content)
        {
            this.Content = Content;
        }

        public static explicit operator OrderItemId(long orderItemId)
        {
            return new OrderItemId(orderItemId);
        }

        public static implicit operator long(OrderItemId orderItemId)
        {
            return orderItemId.Content;
        }
    }
}