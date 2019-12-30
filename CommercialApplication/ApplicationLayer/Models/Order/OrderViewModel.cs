using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.ApplicationLayer.Models.Order
{
    public class OrderViewModel : OrderModelBase
    {
        public IEnumerable<OrderItemCreateModel> orderItems { get; set; }
    }
}
