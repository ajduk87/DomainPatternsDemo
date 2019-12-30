using AutoMapper;
using CommercialApplication.ApplicationLayer.Models.InvoiceItemInvoices;
using CommercialApplication.ApplicationLayer.Models.Invoices;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItem;

namespace CommercialApplicationCommand.ApplicationLayer.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<InvoiceDto, InvoiceViewModel>();

            CreateMap<InvoiceCreateModel, InvoiceDto>();
            CreateMap<InvoiceDeleteModel, InvoiceDto>();

            CreateMap<InvoiceItemCreateModel, InvoiceItemDto>();
            CreateMap<InvoiceItemDeleteModel, InvoiceItemDto>();

            CreateMap<InvoiceItemInvoicesCreateModel, InvoiceItemInvoiceDto>();
            CreateMap<InvoiceItemInvoicesDeleteModel, InvoiceItemInvoiceDto>();
        }
    }
}