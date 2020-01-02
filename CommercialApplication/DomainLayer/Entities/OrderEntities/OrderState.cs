using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.OrderEntities
{
    public class OrderState : Entity
    {
        public State State { get; set; }
    }
}
