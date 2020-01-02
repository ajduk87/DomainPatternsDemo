namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common
{
    public class Name : ValueObject
    {
        public string Content { get; }

        public Name(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator Name(string name)
        {
            return new Name(name);
        }

        public static implicit operator string(Name name)
        {
            return name.Content;
        }
        public override string ToString()
        {
            return this.Content;
        }
    }
}