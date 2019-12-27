namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common
{
    public class IsHyphen : ValueObject
    {
        public bool Content { get; set; }

        public IsHyphen(bool Content)
        {
            this.Content = Content;
        }

        public static explicit operator IsHyphen(bool isHyphen)
        {
            return new IsHyphen(isHyphen);
        }

        public static implicit operator bool(IsHyphen isHyphen)
        {
            return isHyphen.Content;
        }
    }
}