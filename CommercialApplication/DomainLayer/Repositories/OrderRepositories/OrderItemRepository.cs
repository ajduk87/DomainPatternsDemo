using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(OrderItemQueries.Delete, new { id });
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(OrderItemQueries.Exists, new { id });
        }

        public OrderItemHighPriority SelectById(IDbConnection connection, long orderId, IDbTransaction transaction = null)
        {
            return connection.Query<OrderItemHighPriority>(OrderItemQueries.SelectById, new { orderId }).Single();
        }

        public long Insert(IDbConnection connection, OrderItemHighPriority orderItem, IDbTransaction transaction = null)
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

        public void Update(IDbConnection connection, OrderItemHighPriority orderItem, IDbTransaction transaction = null)
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
    }
}