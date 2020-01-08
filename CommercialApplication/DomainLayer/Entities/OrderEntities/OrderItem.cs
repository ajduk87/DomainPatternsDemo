using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.InvoiceItem;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.ProductStorage;

namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities
{
    public class OrderItem : Entity
    {
        public ProductId ProductId { get; set; }
        public Amount Amount { get; set; }
        public Money Value { get; set; }
        public Discount DiscountBasic { get; set; }
        public ActionId ActionId { get; set; }

        public Money ValueWithoutDiscount(UnitCost unitCost)
        {
            return new Money
            {
                Value = this.Amount * unitCost.Value,
                Currency = new Currency("dinara")
            };
        }

        public Money ValueWithDiscountBasic(UnitCost unitCost)
        {
            return new Money
            {
                Value = this.Amount.Content * unitCost.Value * this.DiscountBasic.Content,
                Currency = new Currency("dinara")
            };
        }

        public Money ValueWithDiscountAction(UnitCost unitCost, Action action)
        {
            return new Money
            {
                Value = this.Amount * unitCost.Value * action.Discount,
                Currency = new Currency("dinara")
            };
        }
    }
}