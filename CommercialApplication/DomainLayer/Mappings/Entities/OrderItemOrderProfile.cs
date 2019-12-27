using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Order;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    public class OrderItemOrderProfile : Profile
    {
        public OrderItemOrderProfile()
        {
            CreateMap<OrderItemOrderDto, OrderItemOrder>();
        }
    }
}