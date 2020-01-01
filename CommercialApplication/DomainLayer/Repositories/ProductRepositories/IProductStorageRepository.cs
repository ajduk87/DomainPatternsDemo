using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories
{
    public interface IProductStorageRepository : IRepository
    {
        IEnumerable<ProductStorage> SelectProductFromAllStorages(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<ProductStorage> SelectByStorageId(IDbConnection connection, long id, IDbTransaction transaction = null);
        void Insert(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null);
    }
}