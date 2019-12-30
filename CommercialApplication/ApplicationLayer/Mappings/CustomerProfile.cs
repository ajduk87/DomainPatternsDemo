using AutoMapper;
using CommercialApplication.ApplicationLayer.Models.Customer;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.ApplicationLayer.Models.Customer;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, CustomerViewModel>();

            CreateMap<CustomerCreateModel, CustomerDto>();
            CreateMap<CustomerUpdateModel, CustomerDto>();
            CreateMap<CustomerDeleteModel, CustomerDto>();
        }
    }
}