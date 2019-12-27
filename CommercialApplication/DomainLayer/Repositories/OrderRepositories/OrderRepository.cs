using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities.States;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(OrderQueries.Delete, new { id });
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(OrderQueries.Exists, new { id });
        }

        public long Insert(IDbConnection connection, Order order, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<long>(OrderQueries.Insert, new
            {
                isSynchronized = order.State.GetType().Equals(typeof(SynchronizedState))
            });
        }

        public void Update(IDbConnection connection, Order order, IDbTransaction transaction = null)
        {
            connection.Execute(OrderQueries.Update, new
            {
                id = order.Id,
                isSynchronized = order.State.GetType().Equals(typeof(SynchronizedState))
            });
        }
    }
}