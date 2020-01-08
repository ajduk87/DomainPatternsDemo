using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.Extensions
{
    public static class OrderItemExtensions
    {
        public static Money ValueWithoutDiscount(this OrderItem orderItem, UnitCost unitCost)
        {
            return new Money
            {
                Value = orderItem.Amount * unitCost.Value,
                Currency = new Currency("dinara")
            };
        }

        public static Money ValueWithDiscountBasic(this OrderItem orderItem, UnitCost unitCost)
        {
            return new Money
            {
                Value = orderItem.Amount.Content * unitCost.Value * orderItem.DiscountBasic.Content,
                Currency = new Currency("dinara")
            };
        }

        public static Money ValueWithDiscountAction(this OrderItem orderItem, UnitCost unitCost, Action action)
        {
            return new Money
            {
                Value = orderItem.Amount * unitCost.Value * action.Discount,
                Currency = new Currency("dinara")
            };
        }
    }
}
