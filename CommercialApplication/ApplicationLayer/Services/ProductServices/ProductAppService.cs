using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Services.ProductServices;
using Npgsql;
using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Services.ProductServices
{
    public class ProductAppService : BaseAppService, IProductAppService
    {
        private readonly IProductService productService;

        public ProductAppService()
        {
            this.productService = this.registrationServices.Instance.Container.Resolve<IProductService>();
        }

        public IEnumerable<ProductDto> GetAll()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                IEnumerable<Product> products = this.productService.Select(connection);
                IEnumerable<ProductDto> productDtoes = this.dtoToEntityMapper.MapViewList<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
                return productDtoes;
            }
        }

        public ProductDto Get(string name)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                Product product = this.productService.SelectByName(connection, new Name(name));
                ProductDto productDto = this.dtoToEntityMapper.MapView<Product, ProductDto>(product);
                return productDto;
            }
        }

        public void CreateNewProduct(ProductDto productDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                Product product = this.dtoToEntityMapper.Map<ProductDto, Product>(productDto);
                this.productService.Insert(connection, product);
            }
        }

        public void UpdateExistingProduct(ProductDto productDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                Product product = this.dtoToEntityMapper.Map<ProductDto, Product>(productDto);
                this.productService.Update(connection, product);
            }
        }

        public void RemoveExistingProduct(ProductDto productDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                Product product = this.dtoToEntityMapper.Map<ProductDto, Product>(productDto);
                this.productService.Delete(connection, product);
            }
        }
    }
}