using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public interface IOrderCustomerRepository : IRepository
    {
        void Insert(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        void Update(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null);
    }
}