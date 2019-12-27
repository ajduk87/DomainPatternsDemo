namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common
{
    public class Discount : ValueObject
    {
        public double Content { get; set; }

        public Discount(double Content)
        {
            this.Content = Content;
        }

        public static explicit operator Discount(double discount)
        {
            return new Discount(discount);
        }

        public static implicit operator double(Discount discount)
        {
            return discount.Content;
        }
    }
}