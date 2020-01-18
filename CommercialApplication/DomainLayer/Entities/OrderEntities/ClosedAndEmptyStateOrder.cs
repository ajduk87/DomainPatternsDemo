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
    public class ClosedAndEmptyStateOrder : Entity, IOrder
    {
        //public State State { get; set; }
        public CreationDate CreationDate { get; set; }

        public ClosedAndEmptyStateOrder(long id)
        {
            this.Id = new Id(id);
            //this.State = new State("closedandempty");
            this.CreationDate = new CreationDate(DateTime.Now.ToShortDateString());
        }
    }
}
