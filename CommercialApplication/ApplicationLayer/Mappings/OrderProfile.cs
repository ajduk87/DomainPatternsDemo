using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Order;
using CommercialApplicationCommand.ApplicationLayer.Models.Order;
using System.Linq;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderCreateModel, OrderDto>();
            CreateMap<OrderUpdateModel, OrderDto>()
             .ForMember(dest => dest.orderItems, opt => opt.MapFrom(src => src.orderItems
                                                                              .Where(orderItem => orderItem.IsChanged == true)));
            CreateMap<OrderDeleteModel, OrderDto>();

            CreateMap<OrderItemCreateModel, OrderItemDto>();
            CreateMap<OrderItemUpdateModel, OrderItemDto>();
        }
    }
}