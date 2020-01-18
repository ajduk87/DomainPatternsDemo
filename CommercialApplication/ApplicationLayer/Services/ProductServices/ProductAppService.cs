using Autofac;
using CommercialApplication.ApplicationLayer.Dtoes.Product;
using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Services.ProductServices;
using Npgsql;
using System;
using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Services.ProductServices
{
    public class ProductAppService : BaseAppService, /* IProduct */ AProductAppService
    {
        private readonly /* IProduct */ AProductService productService;

        public ProductAppService()
        {
            this.productService = this.registrationServices.Instance.Container.Resolve</* IProduct */ AProductService>();
        }

        public IEnumerable<ProductDto> GetAll()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                IEnumerable</* IProduct */ AProduct> products = this.productService.Select(connection);
                IEnumerable<ProductDto> productDtoes = this.dtoToEntityMapper.MapViewList<IEnumerable</* IProduct */ AProduct>, IEnumerable<ProductDto>>(products);
                return productDtoes;
            }
        }

        public ProductDto Get(string name)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                /* IProduct */ AProduct product = this.productService.SelectByName(connection, new Name(name));
                ProductDto productDto = this.dtoToEntityMapper.MapView</* IProduct */ AProduct, ProductDto>(product);
                return productDto;
            }
        }

        public void CreateNewProduct(ProductDto productDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                ///* IProduct */ AProduct product = this.dtoToEntityMapper.Map<ProductDto, /* IProduct */ AProduct>(productDto);
                AProduct product = this.dtoToEntityMapper.Map<ProductDto, AProduct>(productDto);
                this.productService.Insert(connection, product);
            }
        }

        public void UpdateExistingProduct(ProductDto productDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                ///* IProduct */ AProduct product = this.dtoToEntityMapper.Map<ProductDto, /* IProduct */ AProduct>(productDto);
                AProduct product = this.dtoToEntityMapper.Map<ProductDto, AProduct>(productDto);
                this.productService.Update(connection, product);
            }
        }

        public void RemoveExistingProduct(ProductDto productDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                ///* IProduct */ AProduct product = this.dtoToEntityMapper.Map<ProductDto, /* IProduct */ AProduct>(productDto);
                AProduct product = this.dtoToEntityMapper.Map<ProductDto, AProduct>(productDto);
                this.productService.Delete(connection, product);
            }
        }

        public void DecreaseUnitcostFruits(DecreaseFruitsUnitCostDto decreaseFruitsUnitCostDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        DecreaseFruitsUnitCost decreaseFruitsUnitCost = this.dtoToEntityMapper.Map<DecreaseFruitsUnitCostDto, DecreaseFruitsUnitCost>(decreaseFruitsUnitCostDto);
                        this.productService.UpdateFruitsUnitCost(connection, decreaseFruitsUnitCost, transaction);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.Write(ex.Message);
                    }
                }
            }
        }

        public void DecreaseUnitcostVegetables(DecreaseVegetablesUnitCostDto decreaseVegetablesUnitCostDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        DecreaseVegetablesUnitCost decreaseVegetablesUnitCost = this.dtoToEntityMapper.Map<DecreaseVegetablesUnitCostDto, DecreaseVegetablesUnitCost>(decreaseVegetablesUnitCostDto);
                        this.productService.UpdateVegetablesUnitCost(connection, decreaseVegetablesUnitCost, transaction);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.Write(ex.Message);
                    }
                }
            }
        }

        /*public void SetState(ProductStateDto productStateDto)
        {
           
        }*/

        public void SetNotForSoldState(string productName)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                this.productService.SetNotForSoldState(connection, new Name(productName));
            }
        }

        public void SetForSoldState(string productName)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                this.productService.SetForSoldState(connection, new Name(productName));
            }
        }

        public void SetOutOfStockState(string productName)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                this.productService.SetOutOfStockState(connection, new Name(productName));
            }
        }

    }
}