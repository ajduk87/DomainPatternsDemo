using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
using CommercialApplicationCommand.DomainLayer.Entities.StorageEntities;
using CommercialApplicationCommand.DomainLayer.Services.StorageServices;
using Npgsql;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Services.ProductServices;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;

namespace CommercialApplicationCommand.ApplicationLayer.Services.StorageServices
{
    public class StorageAppService : BaseAppService, IStorageAppService
    {
        private readonly IProductStorageService productStorageService;
        private readonly IStorageService storageService;

        public StorageAppService()
        {
            this.storageService = this.registrationServices.Instance.Container.Resolve<IStorageService>();
            this.productStorageService = this.registrationServices.Instance.Container.Resolve<IProductStorageService>();
        }

        public void CreateNewStorage(StorageDto storageDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                Storage storage = this.dtoToEntityMapper.Map<StorageDto, Storage>(storageDto);
                this.storageService.Insert(connection, storage);
            }
        }

        public void UpdateExistingStorage(StorageDto storageDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                Storage storage = this.dtoToEntityMapper.Map<StorageDto, Storage>(storageDto);
                this.storageService.Update(connection, storage);
            }
        }

        public void DeleteExistingStorage(StorageDto storageDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                Storage storage = this.dtoToEntityMapper.Map<StorageDto, Storage>(storageDto);
                this.storageService.Delete(connection, storage);
            }
        }

        public void AddProductInStorage(ProductStorageDto productStorageDto)
        {
            using(NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                ProductStorage productStorage = this.dtoToEntityMapper.Map<ProductStorageDto, ProductStorage>(productStorageDto);
                this.productStorageService.Insert(connection, productStorage);
            }
        }

        public void RemoveProductFromStorage(ProductStorageDto productStorageDto)
        {
            using(NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                ProductStorage productStorage = this.dtoToEntityMapper.Map<ProductStorageDto, ProductStorage>(productStorageDto);
                this.productStorageService.Delete(connection, productStorage);
            }
        }
    }
}
