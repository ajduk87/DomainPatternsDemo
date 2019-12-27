using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.ProductServices
{
    public interface IProductStorageService
    {
        void Insert(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null);
    }
}