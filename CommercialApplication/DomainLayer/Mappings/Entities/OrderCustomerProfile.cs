using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Order;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    public class OrderCustomerProfile : Profile
    {
        public OrderCustomerProfile()
        {
            CreateMap<OrderCustomerDto, OrderCustomer>();
        }
    }
}