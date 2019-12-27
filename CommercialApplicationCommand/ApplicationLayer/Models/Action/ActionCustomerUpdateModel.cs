using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.ApplicationLayer.Models.Action
{
    public class ActionCustomerUpdateModel
    {
        public long ProductId { get; set; }
        public double Discount { get; set; }
        public int ThresholdAmount { get; set; }
        public long CustomerId { get; set; }
    }
}
