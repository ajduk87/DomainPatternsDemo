using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    public class InvoicesProfile : Profile
    {
        public InvoicesProfile()
        {
            CreateMap<InvoiceDto, Invoice>();
        }
    }
}