using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;

namespace CommercialApplicationCommand.ApplicationLayer.Services.ProductServices
{
    public interface IProductAppService
    {
        void CreateNewProduct(ProductDto productDto);
        void UpdateExistingProduct(ProductDto productDto);
        void RemoveExistingProduct(ProductDto productDto);
    }
}