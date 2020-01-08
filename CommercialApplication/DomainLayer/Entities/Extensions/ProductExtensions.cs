using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.Extensions
{
    public static class ProductExtensions
    {
        public static Product MyValue(this Product product, Percent discount)
        {
            product.UnitCost.Value = discount.Content * product.UnitCost.Value;
            return product;
        }
    }
}
