using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public interface IOrderRepository : IRepository
    {
        Order SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<Order> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, Order order, IDbTransaction transaction = null);

        void Update(IDbConnection connection, Order order, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);

        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);

        //Order Item
        OrderItem SelectOrderItemById(IDbConnection connection, long orderId, IDbTransaction transaction = null);
        long InsertOrderItem(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);

        void DeleteOrderItem(IDbConnection connection, long id, IDbTransaction transaction = null);

        void UpdateOrderItem(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);

        bool ExistsOrderItem(IDbConnection connection, long id, IDbTransaction transaction = null);

        //Order item order connection
        IEnumerable<long> SelectOrderItemsIdsByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null);
        void InsertOrderItemOrder(IDbConnection connection, OrderItemOrder orderItemOrder, IDbTransaction transaction = null);
        void DeleteOrderItemOrder(IDbConnection connection, long id, IDbTransaction transaction = null);
        bool ExistsOrderItemOrder(IDbConnection connection, long id, IDbTransaction transaction = null);

        //Customer
        Customer SelectCustomerByOrderId(IDbConnection connection, long orderId, IDbTransaction transaction = null);
        void InsertCustomerForOrder(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null);

        void DeleteCustomerForOrder(IDbConnection connection, long id, IDbTransaction transaction = null);
        void UpdateCustomerForOrder(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null);
    }
}