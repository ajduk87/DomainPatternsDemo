
using CommercialApplication.DomainLayer.Entities.OrderEntities.OrderStates;
using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using System;

namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities
{
    public class Order : Entity
    {
        public IOrderState State { get; set; }
        public CreationDate CreationDate { get; set; }

        public Order()
        {
            this.State = new OpenState();
            this.CreationDate = new CreationDate(DateTime.Now.ToShortDateString());
        }

        public Order SetState(State newState)
        {
            if (newState.Equals("open"))
            {
                this.State = this.State.SetOpenState();
            }
            else if (newState.Equals("paused"))
            {
                this.State = this.State.SetPausedState();
            }
            else if (newState.Equals("closed"))
            {
                this.State = this.State.SetClosedState();
            }
            else if (newState.Equals("closedandempty"))
            {
                this.State = this.State.SetClosedAndEmptyState();
            }
            return this;
        }
    }
}