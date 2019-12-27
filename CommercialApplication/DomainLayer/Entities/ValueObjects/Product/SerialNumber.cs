namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Product
{
    public class SerialNumber : ValueObject
    {
        public string Content { get; set; }

        public SerialNumber(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator SerialNumber(string serialNumber)
        {
            return new SerialNumber(serialNumber);
        }

        public static implicit operator string(SerialNumber serialNumber)
        {
            return serialNumber.Content;
        }
    }
}