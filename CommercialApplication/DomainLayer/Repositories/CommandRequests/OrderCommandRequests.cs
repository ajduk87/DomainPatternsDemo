using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.CommandRequests
{
    public static class OrderCommandRequests
    {
        //OrderItem
        public const string DeleteOrderItemById = "DeleteOrderItemById";
        public const string DeleteOrderItemByIds = "DeleteOrderItemByIds";
        public const string GetOrderItemById = "GetOrderItemById";
        public const string GetOrderItemByIds = "GetOrderItemByIds";
        public const string IncludeDiscountForPaying = "IncludeDiscountForPaying";
        public const string InsertListOrderItem = "InsertListOrderItem";
        public const string InsertOrderItem = "InsertOrderItem";
        public const string UpdateListOrderItem = "UpdateListOrderItem";
        public const string UpdateOrderItem = "UpdateOrderItem";

        //OrderItemOrder
        public const string DeleteOrderItemOrder = "DeleteOrderItemOrder";
        public const string InsertOrderItemOrder = "InsertOrderItemOrder";
        public const string GetOrderItemsOrderByOrderId = "GetOrderItemOrderByOrderId";

        //OrderItemCustomer
        public const string DeleteOrderCustomer = "DeleteOrderItemCustomer";
        public const string InsertOrderCustomer = "InsertOrderItemCustomer";
        public const string GetOrderCustomerByOrderId = "GetOrderItemCustomerByOrderId";
    }
}
