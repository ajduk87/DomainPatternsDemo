using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Order
{
    public class OrderDto : Dto
    {
        public long CustomerId { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}