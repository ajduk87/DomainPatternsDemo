using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Models.Order
{
    public class OrderCreateModel : OrderModelBase
    {
        public IEnumerable<OrderItemCreateModel> orderItems { get; set; }
    }
}