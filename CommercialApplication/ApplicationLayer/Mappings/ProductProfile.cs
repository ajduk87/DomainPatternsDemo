using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.ProductStorage;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductCreateModel, ProductDto>()
                .ForMember(dest => dest.UnitCost, opt => opt.MapFrom(src => MakeUnitCost(src.UnitCost)));
            CreateMap<ProductUpdateModel, ProductDto>()
                .ForMember(dest => dest.UnitCost, opt => opt.MapFrom(src => MakeUnitCost(src.UnitCost)));
            CreateMap<ProductDeleteModel, ProductDto>();

            CreateMap<ProductStorageCreateModel, ProductStorageDto>();
            CreateMap<ProductStorageDeleteModel, ProductStorageDto>();
        }

        private string MakeUnitCost(UnitCostModel unitCostModel)
        {
            return $"{unitCostModel.Value} {unitCostModel.Currency}";
        }
    }
}