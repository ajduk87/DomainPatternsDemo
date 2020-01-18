using CommercialApplication.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public interface IOrderService
    {
        IOrder SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<IOrder> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null);
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, IOrder order, IDbTransaction transaction = null);
        void Update(IDbConnection connection, IOrder order, IDbTransaction transaction = null);
        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);        
        long SelectOrderIdWithMaxSumValueByDay(IDbConnection connection, IEnumerable<IOrder> orders, IDbTransaction transaction = null);
        long SelectOrderIdWithMinSumValueByDay(IDbConnection connection, IEnumerable<IOrder> orders, IDbTransaction transaction = null);
        //void UpdateState(IDbConnection connection, OrderState orderState, IDbTransaction transaction = null);
        void UpdateOpenState(IDbConnection connection, Id id, IDbTransaction transaction = null);
        void UpdatePausedState(IDbConnection connection, Id id, IDbTransaction transaction = null);
        void UpdateClosedState(IDbConnection connection, Id id, IDbTransaction transaction = null);
        void UpdateClosedAndEmptyState(IDbConnection connection, Id id, IDbTransaction transaction = null);
    }
}