using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.ProductServices
{
    public interface IProductService
    {
        ProductDto SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null);

        void Insert(IDbConnection connection, Product product, IDbTransaction transaction = null);

        void Update(IDbConnection connection, Product product, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, Product product, IDbTransaction transaction = null);
    }
}