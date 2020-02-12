using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        public Order SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.Query<Order>(OrderQueries.Select, new { id }).Single();
        }

        public IEnumerable<Order> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null)
        {
            return connection.Query<Order>(OrderQueries.SelectByDay, new { day });
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(OrderQueries.Delete, new { id });
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(OrderQueries.Exists, new { id });
        }

        public long Insert(IDbConnection connection, Order order, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<long>(OrderQueries.Insert, new
            {
                state = order.State
            });
        }

        public void Update(IDbConnection connection, Order order, IDbTransaction transaction = null)
        {
            connection.Execute(OrderQueries.Update, new
            {
                id = order.Id,
                state = order.State
            });
        }

        //Order Item
        public OrderItem SelectOrderItemById(IDbConnection connection, long orderId, IDbTransaction transaction = null)
        {
            return connection.Query<OrderItem>(OrderItemQueries.SelectById, new { orderId }).Single();
        }

        public long InsertOrderItem(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<long>(OrderItemQueries.Insert, new
            {
                productId = orderItem.ProductId.Content,
                amount = orderItem.Amount.Content,
                value = orderItem.Value.Value,
                discountBasic = orderItem.DiscountBasic.Content,
                actionId = orderItem.ActionId.Content
            });
        }

        public void UpdateOrderItem(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            connection.Execute(OrderItemQueries.Update, new
            {
                id = orderItem.Id,
                productId = orderItem.ProductId.Content,
                amount = orderItem.Amount.Content,
                value = orderItem.Value.Value,
                discountBasic = orderItem.DiscountBasic.Content,
                actionId = orderItem.ActionId.Content
            });
        }

        public void DeleteOrderItem(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(OrderItemQueries.Delete, new { id });
        }

        public bool ExistsOrderItem(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(OrderItemQueries.Exists, new { id });
        }



        //Order item order connection

        public IEnumerable<long> SelectOrderItemsIdsByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.Query<long>(OrderItemOrderQueries.GetOrderIds, new { orderId = id });
        }

        public void InsertOrderItemOrder(IDbConnection connection, OrderItemOrder orderItemOrder, IDbTransaction transaction = null)
        {
            connection.Execute(OrderItemOrderQueries.Insert, new
            {
                orderId = orderItemOrder.OrderId.Content,
                orderItemId = orderItemOrder.OrderItemId.Content
            });
        }

        public void DeleteOrderItemOrder(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(OrderItemOrderQueries.Delete, new { orderId = id });
        }

        public bool ExistsOrderItemOrder(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(OrderItemOrderQueries.Exists, new { id });
        }

        //Customer
        public Customer SelectCustomerByOrderId(IDbConnection connection, long orderId, IDbTransaction transaction = null)
        {
            return connection.Query<Customer>(OrderCustomerQueries.SelectByOrderId, new { orderId }).Single();
        }

        public void DeleteCustomerForOrder(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(OrderCustomerQueries.Delete, new { orderId = id });
        }

        public void InsertCustomerForOrder(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null)
        {
            connection.Execute(OrderCustomerQueries.Insert, new
            {
                customerId = orderCustomer.CustomerId.Content,
                orderId = orderCustomer.OrderId.Content
            });
        }

        public void UpdateCustomerForOrder(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null)
        {
            connection.Execute(OrderCustomerQueries.Update, new
            {
                orderId = orderCustomer.OrderId.Content,
                customerId = orderCustomer.CustomerId.Content
            });
        }
    }
}