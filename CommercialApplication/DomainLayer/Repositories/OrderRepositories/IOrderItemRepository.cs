using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public interface IOrderItemRepository : IRepository
    {
        OrderItemHighPriority SelectById(IDbConnection connection, long orderId, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, OrderItemHighPriority orderItem, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);

        void Update(IDbConnection connection, OrderItemHighPriority orderItem, IDbTransaction transaction = null);

        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}