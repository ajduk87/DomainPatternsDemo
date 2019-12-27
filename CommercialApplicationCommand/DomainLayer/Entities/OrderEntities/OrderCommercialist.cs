using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities
{
    public class OrderCommercialist : Entity
    {
        public Id OrderId { get; set; }
        public Id CommercialistId { get; set; }
    }
}
