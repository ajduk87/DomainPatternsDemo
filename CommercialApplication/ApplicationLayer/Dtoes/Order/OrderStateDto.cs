using CommercialApplicationCommand.ApplicationLayer.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.ApplicationLayer.Dtoes.Order
{
    public class OrderStateDto : Dto
    {
        public long Id { get; set; }
        public string State { get; set; }
    }
}
