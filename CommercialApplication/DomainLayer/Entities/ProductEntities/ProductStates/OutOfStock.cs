using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ProductEntities.ProductStates
{
    public class OutOfStock : IProductState
    {
        public IProductState SetNotForSoldState()
        {
            return this;
        }

        public IProductState SetForSoldState()
        {
            return new ForSoldState();
        }

        public IProductState SetOutOfStockState()
        {
            return this;
        }
    }
}
