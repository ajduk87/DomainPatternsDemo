using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.OrderEntities.OrderStates
{
    public class PausedState : IOrderState
    {
        public IOrderState SetOpenState()
        {
            return new OpenState();
        }

        public IOrderState SetPausedState()
        {
            return this;
        }

        public IOrderState SetClosedState()
        {
            return this;
        }

        public IOrderState SetClosedAndEmptyState()
        {
            return this;
        }
    }
}
