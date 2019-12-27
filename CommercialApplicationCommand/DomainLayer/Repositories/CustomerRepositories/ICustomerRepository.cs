using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.CustomerRepositories
{
    public interface ICustomerRepository : IRepository
    {
        CustomerDto SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);

        void Insert(IDbConnection connection, Customer customer, IDbTransaction transaction = null);

        void Update(IDbConnection connection, Customer customer, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, Customer customer, IDbTransaction transaction = null);

        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}