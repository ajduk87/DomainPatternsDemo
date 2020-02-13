using AutoMapper;
using CommercialApplication.ApplicationLayer.Dtoes.Order;
using CommercialApplication.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Order;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>();
            CreateMap<OrderItemDto, OrderItemHighPriority>();
            CreateMap<OrderItemOrderDto, OrderItemOrder> ();
            CreateMap<OrderStateDto, OrderState>();
        }
    }
}