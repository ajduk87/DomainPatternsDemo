using CommercialApplication.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories
{
    public interface IOrderRepository : IRepository
    {
        IOrder SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<IOrder> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, IOrder order, IDbTransaction transaction = null);

        void Update(IDbConnection connection, IOrder order, IDbTransaction transaction = null);
        void SetOpenState(IDbConnection connection, OpenStateOrder openStateOrder, IDbTransaction transaction = null);
        void SetPausedState(IDbConnection connection, PausedStateOrder pausedStateOrder, IDbTransaction transaction = null);
        void SetClosedState(IDbConnection connection, ClosedStateOrder closedStateOrder, IDbTransaction transaction = null);
        void SetClosedAndEmptyState(IDbConnection connection, ClosedAndEmptyStateOrder closedAndEmptyStateOrder, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);

        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}