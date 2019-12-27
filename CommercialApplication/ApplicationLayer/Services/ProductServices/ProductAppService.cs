using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Services.ProductServices;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Services.ProductServices
{
    public class ProductAppService : BaseAppService, IProductAppService
    {
        private readonly IProductService productService;

        public ProductAppService()
        {
            this.productService = this.registrationServices.Instance.Container.Resolve<IProductService>();
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