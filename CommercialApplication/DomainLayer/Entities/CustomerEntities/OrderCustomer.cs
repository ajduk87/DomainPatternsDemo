using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;

namespace CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities
{
    public class OrderCustomer : Entity
    {
        public Id CustomerId { get; set; }
        public Id OrderId { get; set; }
    }
}