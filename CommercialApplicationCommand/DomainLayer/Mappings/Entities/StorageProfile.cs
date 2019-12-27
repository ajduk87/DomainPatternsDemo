using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
using CommercialApplicationCommand.DomainLayer.Entities.StorageEntities;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    public class StorageProfile : Profile
    {
        public StorageProfile()
        {
            CreateMap<StorageDto, Storage>()
                .ForMember(dest => dest.LocationOfStorage, opt => opt.MapFrom(src => src.Location));
        }
    }
}