using AutoMapper;
using CommercialApplication.ApplicationLayer.Models.ProductStorage;
using CommercialApplication.ApplicationLayer.Models.Storage;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
using CommercialApplicationCommand.ApplicationLayer.Models.ProductStorage;
using CommercialApplicationCommand.ApplicationLayer.Models.Storage;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    public class StorageProfile : Profile
    {
        public StorageProfile()
        {
            CreateMap<StorageDto, StorageViewModel>();

            CreateMap<StorageCreateModel, StorageDto>();
            CreateMap<StorageUpdateModel, StorageDto>();
            CreateMap<StorageDeleteModel, StorageDto>();


            CreateMap<ProductStorageDto, ProductStorageViewModel>();

            CreateMap<ProductStorageCreateModel, ProductStorageDto>();
            CreateMap<ProductStorageDeleteModel, ProductStorageDto>();
        }
    }
}