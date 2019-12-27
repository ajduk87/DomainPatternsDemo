using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
using CommercialApplicationCommand.ApplicationLayer.Models.Storage;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    public class StorageProfile : Profile
    {
        public StorageProfile()
        {
            CreateMap<StorageCreateModel, StorageDto>();
            CreateMap<StorageUpdateModel, StorageDto>();
            CreateMap<StorageDeleteModel, StorageDto>();
        }
    }
}