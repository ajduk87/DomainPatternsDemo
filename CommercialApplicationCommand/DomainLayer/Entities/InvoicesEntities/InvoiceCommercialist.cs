using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities
{
    public class InvoiceCommercialist : Entity
    {
        public Id CommercialistId { get; set; }
        public Id InvoiceId { get; set; }
    }
}
