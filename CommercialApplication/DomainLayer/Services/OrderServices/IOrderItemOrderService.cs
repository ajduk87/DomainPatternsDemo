using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public interface IOrderItemOrderService
    {
        void InsertList(IDbConnection connection, IEnumerable<OrderItem> orderItems, long orderId, IDbTransaction transaction = null);
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<long> SelectByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}