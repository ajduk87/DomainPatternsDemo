using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.OrderEntities.OrderStates
{
    public interface IOrderState
    {
        IOrderState SetOpenState();
        IOrderState SetPausedState();
        IOrderState SetClosedState();
        IOrderState SetClosedAndEmptyState();
    }
}
