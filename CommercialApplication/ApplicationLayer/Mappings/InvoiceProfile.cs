using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItem;
using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItemInvoices;
using CommercialApplicationCommand.ApplicationLayer.Models.Invoices;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceCreateModel, InvoiceDto>();
            CreateMap<InvoiceDeleteModel, InvoiceDto>();

            CreateMap<InvoiceItemCreateModel, InvoiceItemDto>();
            CreateMap<InvoiceItemDeleteModel, InvoiceItemDto>();

            CreateMap<InvoiceItemInvoicesCreateModel, InvoiceItemInvoiceDto>();
            CreateMap<InvoiceItemInvoicesDeleteModel, InvoiceItemInvoiceDto>();
        }
    }
}