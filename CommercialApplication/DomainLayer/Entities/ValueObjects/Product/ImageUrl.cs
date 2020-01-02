namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Product
{
    public class ImageUrl : ValueObject
    {
        public string Content { get; }

        public ImageUrl(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator ImageUrl(string imageUrl)
        {
            return new ImageUrl(imageUrl);
        }

        public static implicit operator string(ImageUrl imageUrl)
        {
            return imageUrl.Content;
        }

        public override string ToString()
        {
            return this.Content;
        }
    }
}