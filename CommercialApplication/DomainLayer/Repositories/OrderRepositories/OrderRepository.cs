using CommercialApplication.DomainLayer.Repositories.CommandRequests;
using CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands;
using CommercialApplication.DomainLayer.Repositories.OrderRepositories;
using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public class OrderRepository : OrderBaseRepository, IOrderRepository
    {

        public Order SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.Query<Order>(OrderQueries.Select, new { id }).Single();*/
            GetOrderByIdCommand command = (GetOrderByIdCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.GetOrderById];
            return command.Execute(connection, id, transaction);
        }

        public IEnumerable<Order> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null)
        {
            /*return connection.Query<Order>(OrderQueries.SelectByDay, new { day });*/
            GetOrdersByDayCommand command = (GetOrdersByDayCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.GetOrdersByDay];
            return command.Execute(connection, day, transaction);
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*connection.Execute(OrderQueries.Delete, new { id });*/
            DeleteOrderCommand command = (DeleteOrderCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.DeleteOrder];
            command.Execute(connection, id, transaction);
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.ExecuteScalar<bool>(OrderQueries.Exists, new { id });*/
            IsOrderExistCommand command = (IsOrderExistCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.IsOrderExist];
            return command.Execute(connection, id, transaction);
        }

        public void Insert(IDbConnection connection, Order order, IDbTransaction transaction = null)
        {
            /*return connection.ExecuteScalar<long>(OrderQueries.Insert, new
            {
                state = order.State
            });*/
            InsertOrderCommand command = (InsertOrderCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.InsertOrder];
            command.Execute(connection, order, transaction);
        }

        public void Update(IDbConnection connection, Order order, IDbTransaction transaction = null)
        {
            /*connection.Execute(OrderQueries.Update, new
            {
                id = order.Id,
                state = order.State
            });*/
            UpdateOrderCommand command = (UpdateOrderCommand)this.commandOrderCaller.DictCommands[OrderCommandRequests.UpdateOrder];
            command.Execute(connection, order, transaction);
        }
    }
}