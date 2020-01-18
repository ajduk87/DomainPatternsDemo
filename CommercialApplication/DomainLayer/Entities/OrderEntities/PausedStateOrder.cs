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
    public class PausedStateOrder : Entity, IOrder
    {
        //public State State { get; set; }
        public CreationDate CreationDate { get; set; }

        public PausedStateOrder(long id)
        {
            this.Id = new Id(id);
            //this.State = new State("paused");
            this.CreationDate = new CreationDate(DateTime.Now.ToShortDateString());
        }

        public OpenStateOrder SetOpenState()
        {
            return new OpenStateOrder(this.Id);
        }
    }
}
