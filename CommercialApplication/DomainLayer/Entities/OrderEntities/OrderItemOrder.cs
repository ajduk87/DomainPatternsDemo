using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.OrderItemOrder;

namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities
{
    public class OrderItemOrder : Entity
    {
        public OrderItemId OrderItemId { get; set; }
        public OrderId OrderId { get; set; }
    }
}