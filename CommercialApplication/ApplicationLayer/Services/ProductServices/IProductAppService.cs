using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Services.ProductServices
{
    public interface IProductAppService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto Get(string name);
        void CreateNewProduct(ProductDto productDto);
        void UpdateExistingProduct(ProductDto productDto);
        void RemoveExistingProduct(ProductDto productDto);
    }
}