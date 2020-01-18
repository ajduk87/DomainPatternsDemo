using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.ProductServices
{
    public class ProductStorageService : IProductStorageService
    {
        private readonly IProductStorageRepository productStorageRepository;

        public ProductStorageService()
        {
            this.productStorageRepository = RepositoryFactory.CreateProductStorageRepository();
        }

        public IEnumerable<ProductStorage> SelectProductFromAllStorages(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.productStorageRepository.SelectProductFromAllStorages(connection, id);
        }

        public IEnumerable<ProductStorage> SelectByStorageId(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.productStorageRepository.SelectByStorageId(connection, id);
        }

        public void Delete(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null) =>
            this.productStorageRepository.Delete(connection, productStorage);

        public void Insert(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null) =>
            this.productStorageRepository.Insert(connection, productStorage);
    }
}