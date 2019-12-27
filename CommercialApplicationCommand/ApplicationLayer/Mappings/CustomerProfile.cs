using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.ApplicationLayer.Models.Customer;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerCreateModel, CustomerDto>();
            CreateMap<CustomerUpdateModel, CustomerDto>();
            CreateMap<CustomerDeleteModel, CustomerDto>();
        }
    }
}