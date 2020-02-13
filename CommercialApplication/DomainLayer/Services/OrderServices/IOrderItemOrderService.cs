using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public interface IOrderItemOrderService
    {
        void Insert(IDbConnection connection, OrderItemOrder orderItemOrder, IDbTransaction transaction = null);
        void InsertList(IDbConnection connection, IEnumerable<OrderItemHighPriority> orderItems, long orderId, IDbTransaction transaction = null);
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<long> SelectByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}