using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
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

        public void Delete(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null) =>
            this.productStorageRepository.Delete(connection, productStorage);

        public void Insert(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null) =>
            this.productStorageRepository.Insert(connection, productStorage);
    }
}