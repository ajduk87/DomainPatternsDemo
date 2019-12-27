using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    public class InvoiceItemInvoiceProfile : Profile
    {
        public InvoiceItemInvoiceProfile()
        {
            CreateMap<InvoiceItemInvoiceDto, InvoiceItemInvoice>();
        }
    }
}