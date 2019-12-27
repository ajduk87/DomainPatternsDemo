using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public interface IOrderItemOrderRepository : IRepository
    {
        void Insert(IDbConnection connection, OrderItemOrder orderItemOrder, IDbTransaction transaction = null);
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<long> SelectByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}