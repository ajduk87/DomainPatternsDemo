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
    public class OpenStateOrder : AOrder
    {
        //public State State { get; set; }
        public CreationDate CreationDate { get; set; }

        public OpenStateOrder(long id)
        {
            this.Id = new Id(id);
            //this.State = new State("open");
            this.CreationDate = new CreationDate(DateTime.Now.ToShortDateString());
        }

        public PausedStateOrder SetPausedState()
        {
            return new PausedStateOrder(this.Id);
        }

        public ClosedStateOrder SetClosedState()
        {
            return new ClosedStateOrder(this.Id);
        }

        public ClosedAndEmptyStateOrder SetClosedAndEmptyState()
        {
            return new ClosedAndEmptyStateOrder(this.Id);
        }
    }
}
