using CommercialApplication.DomainLayer.Repositories.CommandRequests;
using CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderCustomerCommands;
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
        public Customer SelectByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.Query<Customer>(OrderCustomerQueries.SelectByOrderId, new { orderId }).Single();*/
            GetOrderCustomerByOrderIdCommand command = (GetOrderCustomerByOrderIdCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.GetOrderCustomerByOrderId];
            return command.Execute(connection, id, transaction);
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*connection.Execute(OrderCustomerQueries.Delete, new { orderId = id });*/
            DeleteOrderCustomerCommand command = (DeleteOrderCustomerCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.DeleteOrderCustomer];
            command.Execute(connection, id, transaction);
        }

        public void Insert(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null)
        {
            /*connection.Execute(OrderCustomerQueries.Insert, new
            {
                customerId = orderCustomer.CustomerId.Content,
                orderId = orderCustomer.OrderId.Content
            });*/
            InsertOrderCustomerCommand command = (InsertOrderCustomerCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.InsertOrderCustomer];
            command.Execute(connection, orderCustomer, transaction);
        }

        public void Update(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null)
        {
            /*connection.Execute(OrderCustomerQueries.Update, new
            {
                orderId = orderCustomer.OrderId.Content,
                customerId = orderCustomer.CustomerId.Content
            });*/
            UpdateOrderCustomerCommand command = (UpdateOrderCustomerCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.UpdateOrderCustomer];
            command.Execute(connection, orderCustomer, transaction);
        }
    }
}