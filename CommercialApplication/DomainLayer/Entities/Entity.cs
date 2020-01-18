using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;

namespace CommercialApplicationCommand.DomainLayer.Entities
{
    public abstract class Entity
    {
        public Id Id { get; set; }

    }
}