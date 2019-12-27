namespace CommercialApplicationCommand.ApplicationLayer.Dtoes.Product
{
    public class ProductStorageDto : Dto
    {
        public long ProductId { get; set; }
        public long StorageId { get; set; }
        public int AmountOfProduct { get; set; }
    }
}