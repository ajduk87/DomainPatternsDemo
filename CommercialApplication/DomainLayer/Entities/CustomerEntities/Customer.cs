using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;

namespace CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities
{
    public class Customer : Entity
    {
        public Name Name { get; set; }
    }
}