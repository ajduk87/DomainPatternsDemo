
using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using System;

namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities
{
    public class Order : Entity
    {
        public State State { get; set; }
        public CreationDate CreationDate { get; set; }

        public Order()
        {
            this.State = new State("Open");
            this.CreationDate = new CreationDate(DateTime.Now.ToShortDateString());
        }
    }
}