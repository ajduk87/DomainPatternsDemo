using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public interface IOrderItemRepository : IRepository
    {
        long Insert(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);

        void Update(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);

        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}