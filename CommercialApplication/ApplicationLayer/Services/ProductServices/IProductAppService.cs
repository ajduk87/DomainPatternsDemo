using CommercialApplication.ApplicationLayer.Dtoes.Product;
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
        void DecreaseUnitcostFruits(DecreaseFruitsUnitCostDto decreaseFruitsUnitCostDto);
        void DecreaseUnitcostVegetables(DecreaseVegetablesUnitCostDto decreaseVegetablesUnitCostDto);
        //void SetState(ProductStateDto productStateDto);
        void SetNotForSoldState(string productName);
        void SetForSoldState(string productName);
        void SetOutOfStockState(string productName);
    }
}