using AutoMapper;
using CommercialApplication.ApplicationLayer.Dtoes.Order;
using CommercialApplication.ApplicationLayer.Models.Order;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Order;
using System.Linq;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, OrderViewModel>();

            CreateMap<OrderCreateModel, OrderDto>();
            CreateMap<OrderUpdateModel, OrderDto>()
             .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.orderItems
                                                                              .Where(orderItem => orderItem.IsChanged == true)));
            CreateMap<OrderDeleteModel, OrderDto>();

            CreateMap<OrderItemCreateModel, OrderItemDto>();
            CreateMap<OrderItemUpdateModel, OrderItemDto>();

            CreateMap<OrderStateModel, OrderStateDto>();
        }
    }
}