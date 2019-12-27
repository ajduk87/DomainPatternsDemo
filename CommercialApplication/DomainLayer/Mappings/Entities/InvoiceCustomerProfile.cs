using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    public class InvoiceCustomerProfile : Profile
    {
        public InvoiceCustomerProfile()
        {
            CreateMap<InvoiceCustomerDto, InvoiceCustomer>();
        }
    }
}