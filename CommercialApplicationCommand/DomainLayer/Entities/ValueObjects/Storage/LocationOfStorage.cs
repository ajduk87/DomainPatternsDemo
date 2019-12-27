namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Storage
{
    public class LocationOfStorage : ValueObject
    {
        public string Content { get; }

        public LocationOfStorage(string content)
        {
            Content = content;
        }

        public static explicit operator LocationOfStorage(string locationOfStorage)
        {
            return new LocationOfStorage(locationOfStorage);
        }

        public static implicit operator string(LocationOfStorage locationOfStorage)
        {
            return locationOfStorage.Content;
        }
    }
}