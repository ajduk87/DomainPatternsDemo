
using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using System;
using System.Collections.Generic;

namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities
{
    public class Order : Entity
    {
        public State State { get; set; }
        public CreationDate CreationDate { get; set; }
        public OrderCustomer orderCustomer { get; set; }
        public IEnumerable<OrderItem> orderItems { get; set; }

        public Order()
        {
            this.State = new State("Open");
            this.CreationDate = new CreationDate(DateTime.Now.ToShortDateString());
        }
    }
}