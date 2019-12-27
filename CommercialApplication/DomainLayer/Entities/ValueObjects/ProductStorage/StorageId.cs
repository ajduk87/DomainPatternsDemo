namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.ProductStorage
{
    public class StorageId : ValueObject
    {
        public long Content { get; private set; }

        public StorageId(long Content)
        {
            this.Content = Content;
        }

        public static explicit operator StorageId(long storageId)
        {
            return new StorageId(storageId);
        }

        public static implicit operator long(StorageId storageId)
        {
            return storageId.Content;
        }
    }
}