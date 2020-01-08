using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplication.DomainLayer.Entities.ProductEntities.ProductStates;
using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplication.DomainLayer.Entities.ValueObjects.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Product;

namespace CommercialApplicationCommand.DomainLayer.Entities.ProductEntities
{
    public class Product : Entity
    {
        public Name Name { get; set; }
        public UnitCost UnitCost { get; set; }
        public Description Description { get; set; }
        public ImageUrl ImageUrl { get; set; }
        public VideoLink VideoLink { get; set; }
        public SerialNumber SerialNumber { get; set; }
        public KindOfProduct KindOfProduct { get; set; }
        public IProductState State { get; set; }

        public Product SetState(State newState)
        {
            if (newState.Equals("notforsold"))
            {
                this.State = this.State.SetNotForSoldState();
            }
            else if (newState.Equals("forsold"))
            {
                this.State = this.State.SetForSoldState();
            }
            else if (newState.Equals("outofstock"))
            {
                this.State = this.State.SetNotForSoldState();
            }

            return this;
        }

    }
}