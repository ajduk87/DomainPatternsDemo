namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common
{
    public class Description : ValueObject
    {
        public string Content { get; set; }

        public Description(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator Description(string description)
        {
            return new Description(description);
        }

        public static implicit operator string(Description description)
        {
            return description.Content;
        }
    }
}