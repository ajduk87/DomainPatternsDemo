using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;

namespace CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities
{
    public class Invoice : Entity
    {
        public Id SellingProgramId { get; set; }
    }
}