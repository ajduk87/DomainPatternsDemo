using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;

namespace CommercialApplicationCommand.DomainLayer.Entities.ProductEntities
{
    public class UnitCost : Entity
    {
        public double Value { get; set; }
        public Currency Currency { get; set; }

        public override string ToString()
        {
            return $"{Value} {Currency.Content}";
        }
    }
}