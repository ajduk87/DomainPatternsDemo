using CommercialClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialClientApplication.Services
{
    public interface IOrderService
    {
        void CreateNewOrder(Order order);
        OrderInfo GetOrderInfo(long id);
    }
}
