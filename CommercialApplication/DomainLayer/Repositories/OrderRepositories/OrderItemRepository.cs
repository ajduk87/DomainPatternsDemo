using CommercialApplication.DomainLayer.Repositories.CommandRequests;
using CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands;
using CommercialApplication.DomainLayer.Repositories.OrderRepositories;
using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public class OrderItemRepository : OrderBaseRepository, IOrderItemRepository
    {
      
        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*connection.Execute(OrderItemQueries.Delete, new { id });*/
            DeleteOrderItemByIdCommand command = (DeleteOrderItemByIdCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.DeleteOrderItemById];
            command.Execute(connection, id, transaction);
        }

        public void DeleteByIds(IDbConnection connection, IEnumerable<long> ids, IDbTransaction transaction = null)
        {
            DeleteOrderItemByIdsCommand command = (DeleteOrderItemByIdsCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.DeleteOrderItemByIds];
            command.Execute(connection, ids, transaction);
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(OrderItemQueries.Exists, new { id });
        }

        public OrderItem SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.Query<OrderItem>(OrderItemQueries.SelectById, new { orderId }).Single();*/
            GetOrderItemByIdCommand command = (GetOrderItemByIdCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.GetOrderItemById];
            return command.Execute(connection, id, transaction);
        }

        public IEnumerable<OrderItem> SelectByIds(IDbConnection connection, IEnumerable<long> ids, IDbTransaction transaction = null)
        {
            GetOrderItemByIdsCommand command = (GetOrderItemByIdsCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.GetOrderItemByIds];
            return command.Execute(connection, ids, transaction);
        }

        public void Insert(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            /*return connection.ExecuteScalar<long>(OrderItemQueries.Insert, new
            {
                productId = orderItem.ProductId.Content,
                amount = orderItem.Amount.Content,
                value = orderItem.Value.Value,
                discountBasic = orderItem.DiscountBasic.Content,
                actionId = orderItem.ActionId.Content
            });*/
            InsertOrderItemCommand command = (InsertOrderItemCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.InsertOrderItem];
            command.Execute(connection, orderItem, transaction);
        }

        public void InsertList(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null)
        {
            InsertListOrderItemCommand command = (InsertListOrderItemCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.InsertListOrderItem];
            command.Execute(connection, orderItems, transaction);
        }

        public void Update(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            /*connection.Execute(OrderItemQueries.Update, new
            {
                id = orderItem.Id,
                productId = orderItem.ProductId.Content,
                amount = orderItem.Amount.Content,
                value = orderItem.Value.Value,
                discountBasic = orderItem.DiscountBasic.Content,
                actionId = orderItem.ActionId.Content
            });*/
            UpdateOrderItemCommand command = (UpdateOrderItemCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.UpdateOrderItem];
            command.Execute(connection, orderItem, transaction);
        }

        public void UpdateList(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null)
        {
            UpdateListOrderItemCommand command = (UpdateListOrderItemCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.UpdateListOrderItem];
            command.Execute(connection, orderItems, transaction);
        }

        public void IncludeDiscountForPaying(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null)
        {
            IncludeDiscountForPayingCommand command = (IncludeDiscountForPayingCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.IncludeDiscountForPaying];
            command.Execute(connection, orderItems, transaction);
        }      
    }
}