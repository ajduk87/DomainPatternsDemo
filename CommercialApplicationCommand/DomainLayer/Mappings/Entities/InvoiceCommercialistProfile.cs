using AutoMapper;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.DomainLayer.Mappings.Entities
{
    public class InvoiceCommercialistProfile : Profile
    {
        public InvoiceCommercialistProfile()
        {
            CreateMap<InvoiceCommercialistDto, InvoiceCommercialist>();
        }
    }
}
