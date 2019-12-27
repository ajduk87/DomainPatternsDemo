using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService()
        {
            this.productRepository = RepositoryFactory.CreateProductRepository();
        }

        public ProductDto SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            return this.productRepository.SelectByName(connection, name);
        }

        public void Insert(IDbConnection connection, Product product, IDbTransaction transaction = null) =>
            this.productRepository.Insert(connection, product);

        public void Update(IDbConnection connection, Product product, IDbTransaction transaction = null) =>
            this.productRepository.Update(connection, product);

        public void Delete(IDbConnection connection, Product product, IDbTransaction transaction = null) =>
            this.productRepository.Delete(connection, product);
    }
}