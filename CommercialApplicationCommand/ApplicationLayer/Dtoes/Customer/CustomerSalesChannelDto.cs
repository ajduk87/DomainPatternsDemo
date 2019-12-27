using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer
{
    public class CustomerSalesChannelDto : Dto
    {
        public long CustomerId { get; set; }
        public long SalesChannelId { get; set; }
    }
}
