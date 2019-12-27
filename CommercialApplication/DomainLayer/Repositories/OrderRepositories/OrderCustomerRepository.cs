using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public class OrderCustomerRepository : IOrderCustomerRepository
    {
        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(OrderCustomerQueries.Delete, new { orderId = id });
        }

        public void Insert(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null)
        {
            connection.Execute(OrderCustomerQueries.Insert, new
            {
                customerId = orderCustomer.CustomerId.Content,
                orderId = orderCustomer.OrderId.Content
            });
        }

        public void Update(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null)
        {
            connection.Execute(OrderCustomerQueries.Update, new
            {
                orderId = orderCustomer.OrderId.Content,
                customerId = orderCustomer.CustomerId.Content
            });
        }
    }
}