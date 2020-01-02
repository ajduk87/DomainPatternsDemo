using AutoMapper;
using CommercialApplication.ApplicationLayer.Dtoes.Product;
using CommercialApplication.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.ProductStorage;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, ProductViewModel>()
                .ForMember(dest => dest.UnitCost, opt => opt.MapFrom(src => MakeUnitCost(src.UnitCost)));
            CreateMap<ProductViewModel, ProductDto>();

            CreateMap<ProductCreateModel, ProductDto>()
                .ForMember(dest => dest.UnitCost, opt => opt.MapFrom(src => MakeUnitCost(src.UnitCost)));
            CreateMap<ProductUpdateModel, ProductDto>()
                .ForMember(dest => dest.UnitCost, opt => opt.MapFrom(src => MakeUnitCost(src.UnitCost)));
            CreateMap<ProductDeleteModel, ProductDto>();

            CreateMap<DecreaseFruitsUnitCostModel, DecreaseFruitsUnitCostDto>();
            CreateMap<DecreaseVegetablesUnitCostModel, DecreaseVegetablesUnitCostDto>();

            CreateMap<ProductStateModel, ProductStateDto>();
        }

        private string MakeUnitCost(UnitCostModel unitCostModel)
        {
            return $"{unitCostModel.Value} {unitCostModel.Currency}";
        }

        private UnitCostModel MakeUnitCost(string unitCost)
        {
            string[] fragments = unitCost.Split(' ');
            return new UnitCostModel
            {
                Value = double.Parse(fragments[0]),
                Currency = fragments[1]
            };
        }
    }
}