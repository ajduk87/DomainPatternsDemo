using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Order
{
    public class OrderCommercialistDto : Dto
    {
        public long CommercialistId { get; set; }
        public long OrderId { get; set; }
    }
}
