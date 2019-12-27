using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public interface IOrderItemService
    {
        long Insert(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);

        void Update(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);

        Money IncludeBasicDiscountForPaying(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null);
    }
}