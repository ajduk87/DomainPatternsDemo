using CommercialApplication.DomainLayer.Entities.OrderEntities;
using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        public IOrder SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.Query<IOrder>(OrderQueries.Select, new { id }).Single();
        }

        public IEnumerable<IOrder> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null)
        {
            return connection.Query<IOrder>(OrderQueries.SelectByDay, new { day });
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(OrderQueries.Delete, new { id });
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(OrderQueries.Exists, new { id });
        }

        public long Insert(IDbConnection connection, IOrder order, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<long>(OrderQueries.Insert, new
            {
                state = new OpenStateOrder(order.Id)
            });
        }

        public void Update(IDbConnection connection, IOrder order, IDbTransaction transaction = null)
        {
            connection.Execute(OrderQueries.Update, new
            {
                id = order.Id,
                //state = order.State
            });
        }

        public void SetOpenState(IDbConnection connection, OpenStateOrder openStateOrder, IDbTransaction transaction = null)
        {
            connection.Execute(OrderQueries.SetOpenState, new
            {
                id = openStateOrder.Id
            });
        }
        public void SetPausedState(IDbConnection connection, PausedStateOrder pausedStateOrder, IDbTransaction transaction = null)
        {
            connection.Execute(OrderQueries.SetPausedState, new
            {
                id = pausedStateOrder.Id
            });
        }
        public void SetClosedState(IDbConnection connection, ClosedStateOrder closedStateOrder, IDbTransaction transaction = null)
        {
            connection.Execute(OrderQueries.SetClosedState, new
            {
                id = closedStateOrder.Id
            });
        }
        public void SetClosedAndEmptyState(IDbConnection connection, ClosedAndEmptyStateOrder closedAndEmptyStateOrder, IDbTransaction transaction = null)
        {
            connection.Execute(OrderQueries.SetClosedAndEmptyState, new
            {
                id = closedAndEmptyStateOrder.Id
            });
        }
    }
}