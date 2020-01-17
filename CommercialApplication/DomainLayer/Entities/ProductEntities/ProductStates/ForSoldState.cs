using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ProductEntities.ProductStates
{
    public class ForSoldState : IProductState
    {
        public IProductState SetNotForSoldState()
        {
            return new NotForSoldState();
        }

        public IProductState SetForSoldState()
        {
            return this;
        }

        public IProductState SetOutOfStockState()
        {
            return this;
        }
    }
}
