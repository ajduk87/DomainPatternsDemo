using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ProductEntities.ProductStates
{
    public interface IProductState
    {
        IProductState SetNotForSoldState();
        IProductState SetForSoldState();
        IProductState SetOutOfStockState();
    }
}
