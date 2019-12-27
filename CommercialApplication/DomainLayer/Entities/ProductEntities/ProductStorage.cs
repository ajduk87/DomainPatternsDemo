using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.ProductStorage;

namespace CommercialApplicationCommand.DomainLayer.Entities.ProductEntities
{
    public class ProductStorage : Entity
    {
        public ProductId ProductId { get; set; }
        public StorageId StorageId { get; set; }
        public Amount AmountOfProduct { get; set; }
    }
}