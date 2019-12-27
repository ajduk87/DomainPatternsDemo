namespace CommercialApplicationCommand.ApplicationLayer.Models.ProductStorage
{
    public abstract class ProductStorageModelBase
    {
        public long ProductId { get; set; }
        public long StorageId { get; set; }
        public int AmountOfProduct { get; set; }
    }
}