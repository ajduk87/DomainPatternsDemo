namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.ProductStorage
{
    public class AmountOfProduct : ValueObject
    {
        public long Content { get; private set; }

        public AmountOfProduct(long Content)
        {
            this.Content = Content;
        }

        public static explicit operator AmountOfProduct(long amountOfProduct)
        {
            return new AmountOfProduct(amountOfProduct);
        }

        public static implicit operator long(AmountOfProduct amountOfProduct)
        {
            return amountOfProduct.Content;
        }
    }
}