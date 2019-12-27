namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.ProductStorage
{
    public class ProductId : ValueObject
    {
        public long Content { get; private set; }

        public ProductId(long Content)
        {
            this.Content = Content;
        }

        public static explicit operator ProductId(long productId)
        {
            return new ProductId(productId);
        }

        public static implicit operator long(ProductId productId)
        {
            return productId.Content;
        }
    }
}