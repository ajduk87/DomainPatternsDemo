using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.ProductStorage;

namespace CommercialApplicationCommand.DomainLayer.Entities.ActionEntities
{
    public class ActionEntity : Entity
    {
        public Id ProductId { get; set; }
        public Id SalesChannelId { get; set; }
        public Discount Discount { get; set; }
        public Amount ThresholdAmount { get; set; }
        public Id CustomerId { get; set; }
    }
}