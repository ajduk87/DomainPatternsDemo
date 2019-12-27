using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Models.Order
{
    public class OrderUpdateModel : OrderModelBase
    {
        public long Id { get; set; }
        public IEnumerable<OrderItemUpdateModel> orderItems { get; set; }
    }
}