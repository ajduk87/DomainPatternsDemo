namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common
{
    public class Amount : ValueObject
    {
        public int Content;

        public Amount(int Content)
        {
            this.Content = Content;
        }

        public static explicit operator Amount(int amount)
        {
            return new Amount(amount);
        }

        public static implicit operator int(Amount amount)
        {
            return amount.Content;
        }
    }
}