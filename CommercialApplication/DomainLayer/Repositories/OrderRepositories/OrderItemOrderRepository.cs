using CommercialApplication.DomainLayer.Repositories.CommandRequests;
using CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderItemOrderCommands;
using CommercialApplication.DomainLayer.Repositories.OrderRepositories;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public class OrderItemOrderRepository : OrderBaseRepository, IOrderItemOrderRepository
    {

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*connection.Execute(OrderItemOrderQueries.Delete, new { orderId = id });*/
            DeleteOrderItemOrderCommand command = (DeleteOrderItemOrderCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.DeleteOrderItemOrder];
            command.Execute(connection, id, transaction);
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.ExecuteScalar<bool>(OrderItemOrderQueries.Exists, new { id });*/
            IsOrderItemOrderExistCommand command = (IsOrderItemOrderExistCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.IsOrderItemOrderExist];
            return command.Execute(connection, id, transaction);
        }

        public IEnumerable<long> SelectByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.Query<long>(OrderItemOrderQueries.GetOrderIds, new { orderId = id });*/
            GetOrderItemsOrderByOrderIdCommand command = (GetOrderItemsOrderByOrderIdCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.GetOrderItemsOrderByOrderId];
            return command.Execute(connection, id, transaction);
        }

        //public void Insert(IDbConnection connection, OrderItemOrder orderItemOrder, IDbTransaction transaction = null)
        public void Insert(IDbConnection connection, IEnumerable<OrderItem> orderItems, long orderId, IDbTransaction transaction = null)
        {
            /*connection.Execute(OrderItemOrderQueries.Insert, new
            {
                orderId = orderItemOrder.OrderId.Content,
                orderItemId = orderItemOrder.OrderItemId.Content
            });*/
            InsertOrderItemOrderCommand command = (InsertOrderItemOrderCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.InsertOrderItemOrder];
            command.Execute(connection, orderItems, orderId, transaction);
        }
    }
}