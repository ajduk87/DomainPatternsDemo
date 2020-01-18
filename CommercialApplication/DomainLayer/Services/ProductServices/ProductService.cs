using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.ProductServices
{
    public class ProductService : /* IProduct */ AProductService
    {
        private readonly /* IProduct */ AProductRepository productRepository;

        public ProductService()
        {
            this.productRepository = RepositoryFactory.CreateProductRepository();
        }

        public IEnumerable</* IProduct */ AProduct> Select(IDbConnection connection, IDbTransaction transaction = null)
        {
            return this.productRepository.Select(connection);
        }

        public /* IProduct */ AProduct SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            return this.productRepository.SelectByName(connection, name);
        }

        public void Insert(IDbConnection connection, /* IProduct */ AProduct product, IDbTransaction transaction = null) =>
            this.productRepository.Insert(connection, product);

        public void Update(IDbConnection connection, /* IProduct */ AProduct product, IDbTransaction transaction = null) =>
            this.productRepository.Update(connection, product);

        public void UpdateFruitsUnitCost(IDbConnection connection, DecreaseFruitsUnitCost decreaseFruitsUnitCost, IDbTransaction transaction = null)
        {
            IEnumerable</* IProduct */ AProduct> products = this.productRepository.SelectAllFruits(connection);
            foreach (/* IProduct */ AProduct product in products)
            {
                product.UnitCost.Value = decreaseFruitsUnitCost.Percent.Content * product.UnitCost.Value;
                this.productRepository.Update(connection, product, transaction);
            }
        }

        public void UpdateVegetablesUnitCost(IDbConnection connection, DecreaseVegetablesUnitCost decreaseVegetablesUnitCost, IDbTransaction transaction = null)
        {
            IEnumerable</* IProduct */ AProduct> products = this.productRepository.SelectAllVegetables(connection);
            foreach (/* IProduct */ AProduct product in products)
            {
                product.UnitCost.Value = decreaseVegetablesUnitCost.Percent.Content * product.UnitCost.Value;
                this.productRepository.Update(connection, product, transaction);
            }
        }

        /*public void UpdateState(IDbConnection connection, ProductState productState, IDbTransaction transaction = null)
        {
            Product product = this.productRepository.SelectByName(connection, productState.Name);           

            this.productRepository.Update(connection, product.SetState(productState.State), transaction);
        }*/

        public void SetNotForSoldState(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            /* IProduct */ AProduct product = this.productRepository.SelectByName(connection, name);

            this.productRepository.Update(connection, new NotForSoldStateProduct(product), transaction);
        }
        public void SetForSoldState(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            /* IProduct */ AProduct product = this.productRepository.SelectByName(connection, name);

            this.productRepository.Update(connection, new ForSoldStateProduct(product), transaction);
        }
        public void SetOutOfStockState(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            /* IProduct */ AProduct product = this.productRepository.SelectByName(connection, name);
            OutOfStockStateProduct outOfStockProduct = (OutOfStockStateProduct)product;

            this.productRepository.Update(connection, new OutOfStockStateProduct(product), transaction);
        }

        public void Delete(IDbConnection connection, /* IProduct */ AProduct product, IDbTransaction transaction = null) =>
            this.productRepository.Delete(connection, product);
    }
}