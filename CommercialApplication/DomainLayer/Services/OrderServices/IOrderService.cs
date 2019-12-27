using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public interface IOrderService
    {
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, Order order, IDbTransaction transaction = null);
        void Update(IDbConnection connection, Order order, IDbTransaction transaction = null);
        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}