using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}