using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
using System.Collections.Generic;
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

        public IEnumerable<Product> Select(IDbConnection connection, IDbTransaction transaction = null)
        {
            return this.productRepository.Select(connection);
        }

        public Product SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            return this.productRepository.SelectByName(connection, name);
        }

        public void Insert(IDbConnection connection, Product product, IDbTransaction transaction = null) =>
            this.productRepository.Insert(connection, product);

        public void Update(IDbConnection connection, Product product, IDbTransaction transaction = null) =>
            this.productRepository.Update(connection, product);

        public void UpdateFruitsUnitCost(IDbConnection connection, DecreaseFruitsUnitCost decreaseFruitsUnitCost, IDbTransaction transaction = null) =>
            this.productRepository.UpdateFruitsUnitCost(connection, decreaseFruitsUnitCost, transaction);

        /*public void UpdateFruitsUnitCost(IDbConnection connection, DecreaseFruitsUnitCost decreaseFruitsUnitCost, IDbTransaction transaction = null)
        {
            IEnumerable<Product> products = this.productRepository.SelectAllFruits(connection);
            foreach (Product product in products)
            {
                product.UnitCost.Value = decreaseFruitsUnitCost.Percent.Content * product.UnitCost.Value;
                this.productRepository.Update(connection, product, transaction);
            }
        }*/


        public void UpdateVegetablesUnitCost(IDbConnection connection, DecreaseVegetablesUnitCost decreaseVegetablesUnitCost, IDbTransaction transaction = null) =>
            this.productRepository.UpdateVegetablesUnitCost(connection, decreaseVegetablesUnitCost, transaction);
        /*public void UpdateVegetablesUnitCost(IDbConnection connection, DecreaseVegetablesUnitCost decreaseVegetablesUnitCost, IDbTransaction transaction = null)
        {
            IEnumerable<Product> products = this.productRepository.SelectAllVegetables(connection);
            foreach (Product product in products)
            {
                product.UnitCost.Value = decreaseVegetablesUnitCost.Percent.Content * product.UnitCost.Value;
                this.productRepository.Update(connection, product, transaction);
            }
        }*/

        public void UpdateState(IDbConnection connection, ProductState productState, IDbTransaction transaction = null) =>
            this.productRepository.UpdateState(connection, productState, transaction);
        /*public void UpdateState(IDbConnection connection, ProductState productState, IDbTransaction transaction = null)
        {
            Product product = this.productRepository.SelectByName(connection, productState.Name);
            product.State = productState.State;
            this.productRepository.Update(connection, product, transaction);
        }*/

        public void Delete(IDbConnection connection, Product product, IDbTransaction transaction = null) =>
            this.productRepository.Delete(connection, product);
    }
}