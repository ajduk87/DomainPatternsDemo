using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;

namespace CommercialApplicationCommand.ApplicationLayer.Services.StorageServices
{
    internal interface IStorageAppService
    {
        void CreateNewStorage(StorageDto storageDto);

        void UpdateExistingStorage(StorageDto storageDto);

        void DeleteExistingStorage(StorageDto storageDto);

        void AddProductInStorage(ProductStorageDto productStorageDto);

        void RemoveProductFromStorage(ProductStorageDto productStorageDto);
    }
}