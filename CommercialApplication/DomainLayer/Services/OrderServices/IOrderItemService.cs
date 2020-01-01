using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public interface IOrderItemService
    {
        OrderItem SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<OrderItem> SelectByIds(IDbConnection connection, IEnumerable<long> ids, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);

        void Update(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);

        Money IncludeBasicDiscountForPaying(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);
        Money IncludeActionDiscountForPaying(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);
    }
}