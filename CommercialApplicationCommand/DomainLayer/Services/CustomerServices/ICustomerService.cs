using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.CustomerServices
{
    public interface ICustomerService
    {
        CustomerDto SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);

        void Insert(IDbConnection connection, Customer customer, IDbTransaction transaction = null);

        void Update(IDbConnection connection, Customer customer, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, Customer customer, IDbTransaction transaction = null);
    }
}