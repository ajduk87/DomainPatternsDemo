using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System;

namespace CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities
{
    public class Invoice : Entity
    {
        public Id SellingProgramId { get; set; }
        public Id OrderId { get; set; }
        public CreationDate CreationDate { get; set; }

        public Invoice()
        {
            this.CreationDate = new CreationDate(DateTime.Now.ToShortDateString());
        }
    }
}