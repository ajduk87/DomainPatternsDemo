using CommercialApplication.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public interface IOrderService
    {
        Order SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<Order> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null);
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, Order order, IDbTransaction transaction = null);
        void Update(IDbConnection connection, Order order, IDbTransaction transaction = null);
        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
        long SelectOrderIdWithMaxSumValueByDay(IDbConnection connection, IEnumerable<Order> orders, IDbTransaction transaction = null);
        long SelectOrderIdWithMinSumValueByDay(IDbConnection connection, IEnumerable<Order> orders, IDbTransaction transaction = null);
        void UpdateState(IDbConnection connection, OrderState orderState, IDbTransaction transaction = null);

        //OrderCustomer
        Customer SelectOrderCustomerByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null);
        void InsertOrderCustomer(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null);

        void DeleteOrderCustomer(IDbConnection connection, long id, IDbTransaction transaction = null);
        void UpdateOrderCustomer(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null);

        //OrderItem
        OrderItem SelectOrderItemById(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<OrderItem> SelectOrderItemByIds(IDbConnection connection, IEnumerable<long> ids, IDbTransaction transaction = null);
        long InsertOrderItem(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);
        void InsertListOrderItem(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null);

        void UpdateOrderItem(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);
        void UpdateOrderItemList(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null);
        void DeleteOrderItem(IDbConnection connection, long id, IDbTransaction transaction = null);
        void DeleteOrderItemByIds(IDbConnection connection, IEnumerable<long> ids, IDbTransaction transaction = null);

        IEnumerable<OrderItem> IncludeBasicDiscountForPaying(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null);
        IEnumerable<OrderItem> IncludeActionDiscountForPaying(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null);

        //OrderItemOrder
        void InsertOrderItemOrder(IDbConnection connection, OrderItemOrder orderItemOrder, IDbTransaction transaction = null);
        void InsertOrderItemOrderList(IDbConnection connection, IEnumerable<OrderItem> orderItems, long orderId, IDbTransaction transaction = null);
        void DeleteOrderItemOrder(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<long> SelectOrderItemOrderByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}