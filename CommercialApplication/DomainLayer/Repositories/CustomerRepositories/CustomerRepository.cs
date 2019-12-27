using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerDto SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.Query<CustomerDto>(CustomerQueries.SelectById, new { id }).Single();
        }

        public void Insert(IDbConnection connection, Customer customer, IDbTransaction transaction = null)
        {
            connection.Execute(CustomerQueries.Insert, new { Name = customer.Name.Content });
        }

        public void Update(IDbConnection connection, Customer customer, IDbTransaction transaction = null)
        {
            connection.Execute(CustomerQueries.Update, new { id = customer.Id, Name = customer.Name.Content });
        }

        public void Delete(IDbConnection connection, Customer customer, IDbTransaction transaction = null)
        {
            connection.Execute(CustomerQueries.Delete, new { id = customer.Id });
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(CustomerQueries.Exists, new { id });
        }
    }
}