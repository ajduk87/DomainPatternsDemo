using AutoMapper;
using CommercialApplication.ApplicationLayer.Dtoes.Product;
using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, IProduct>();
            CreateMap<ProductStateDto, ProductState>();
            CreateMap<ProductStorageDto, ProductStorage>();
            CreateMap<DecreaseFruitsUnitCostDto, DecreaseFruitsUnitCost>();
            CreateMap<DecreaseVegetablesUnitCostDto, DecreaseVegetablesUnitCost>();
        }
    }
}