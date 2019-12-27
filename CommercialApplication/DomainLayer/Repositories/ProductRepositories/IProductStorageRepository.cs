using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories
{
    public interface IProductStorageRepository : IRepository
    {
        void Insert(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null);
    }
}