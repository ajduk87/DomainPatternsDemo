using AutoMapper;
using CommercialApplication.ApplicationLayer.Dtoes.Product;
using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.UnitCost, opt => opt.MapFrom(src => MakeUnitCost(src.UnitCost)));
            CreateMap<Product, ProductDto>();
            CreateMap<ProductStateDto, ProductState>();
            CreateMap<ProductStorageDto, ProductStorage>();
            CreateMap<DecreaseFruitsUnitCostDto, DecreaseFruitsUnitCost>();
            CreateMap<DecreaseVegetablesUnitCostDto, DecreaseVegetablesUnitCost>();
        }

        private UnitCost MakeUnitCost(string unitCost)
        {
            string[] fragments = unitCost.Split(' ');
            return new UnitCost
            {
                Value = double.Parse(fragments[0]),
                Currency = new Currency(fragments[1])
            };
        }

        //private string MakeUnitCost(UnitCost unitCost)
        //{
        //    return $"{unitCost.Value} {unitCost.Currency.Content}";
        //}
    }
}