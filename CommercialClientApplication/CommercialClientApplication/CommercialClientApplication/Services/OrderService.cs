using CommercialClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Services
{
    public class OrderService : IOrderService
    {
        public void CreateNewOrder(Order order)
        {
        }
        public OrderInfo GetOrderInfo(long id)
        {
            return new OrderInfo();
        }
    }
}
