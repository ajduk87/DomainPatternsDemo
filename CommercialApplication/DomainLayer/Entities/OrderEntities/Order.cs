
namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities
{
    public class Order : Entity
    {
        public string State { get; set; }

        public Order()
        {
            this.State = "Open";
        }
    }
}