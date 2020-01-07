using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.OrderEntities.OrderStates
{
    public class OpenState : IOrderState
    {
        public IOrderState SetOpenState()
        {
            return this;
        }

        public IOrderState SetPausedState()
        {
            return new PausedState();
        }

        public IOrderState SetClosedState()
        {
            return new ClosedState();
        }

        public IOrderState SetClosedAndEmptyState()
        {
            return new ClosedAndEmptyState();
        }
    }
}
