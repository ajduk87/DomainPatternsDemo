using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.OrderEntities.OrderStates
{
    public class ClosedAndEmptyState : IOrderState
    {
        public IOrderState SetOpenState()
        {
            return this;
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
