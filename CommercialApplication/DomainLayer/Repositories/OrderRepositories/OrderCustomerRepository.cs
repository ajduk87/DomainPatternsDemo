using CommercialApplication.DomainLayer.Repositories.OrderRepositories;
using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public class OrderCustomerRepository : OrderBaseRepository, IOrderCustomerRepository
    {
        public OrderCustomerRepository()
        {
        }
        public Customer SelectByOrderId(IDbConnection connection, long orderId, IDbTransaction transaction = null)
        {
            return connection.Query<Customer>(OrderCustomerQueries.SelectByOrderId, new { orderId }).Single();
        }

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