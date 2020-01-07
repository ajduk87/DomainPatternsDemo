using CommercialApplication.DomainLayer.Entities.ProductEntities;
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
        public State State { get; set; }

        public Product SetState(State newState)
        {
            if (newState.Equals("notforsold"))
            {
                if (this.State.Equals("notforsold"))
                {
                    //stay in notforsold state
                    this.State = new State("notforsold");
                }
                if (this.State.Equals("forsold"))
                {
                    //transit to notforsold state
                    this.State = new State("notforsold");
                }
                if (this.State.Equals("outofstock"))
                {
                    //stay in state outofstock
                    this.State = new State("outofstock");
                }
            }
            else if (newState.Equals("forsold"))
            {
                if (this.State.Equals("notforsold"))
                {
                    //transit to forsold state
                    this.State = new State("forsold");
                }
                if (this.State.Equals("forsold"))
                {
                    //stay in forsold state
                    this.State = new State("forsold");
                }
                if (this.State.Equals("outofstock"))
                {
                    //stay in state outofstock
                    this.State = new State("outofstock");
                }
            }
            else if (newState.Equals("outofstock"))
            {
                if (this.State.Equals("notforsold"))
                {
                    //stay in notforsold state
                    this.State = new State("notforsold");
                }
                if (this.State.Equals("forsold"))
                {
                    //transit to forsold state
                    this.State = new State("outofstock");
                }
                if (this.State.Equals("outofstock"))
                {
                    //stay in state outofstock
                    this.State = new State("outofstock");
                }
            }

            return this;
        }

    }
}