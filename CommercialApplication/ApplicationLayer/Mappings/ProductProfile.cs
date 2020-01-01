using AutoMapper;
using CommercialApplication.ApplicationLayer.Dtoes.Product;
using CommercialApplication.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.ProductStorage;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, ProductViewModel>();

            CreateMap<ProductCreateModel, ProductDto>()
                .ForMember(dest => dest.UnitCost, opt => opt.MapFrom(src => MakeUnitCost(src.UnitCost)));
            CreateMap<ProductUpdateModel, ProductDto>()
                .ForMember(dest => dest.UnitCost, opt => opt.MapFrom(src => MakeUnitCost(src.UnitCost)));
            CreateMap<ProductDeleteModel, ProductDto>();

            CreateMap<DecreaseFruitsUnitCostModel, DecreaseFruitsUnitCostDto>();
            CreateMap<DecreaseVegetablesUnitCostModel, DecreaseVegetablesUnitCostDto>();
        }

        private string MakeUnitCost(UnitCostModel unitCostModel)
        {
            return $"{unitCostModel.Value} {unitCostModel.Currency}";
        }
    }
}