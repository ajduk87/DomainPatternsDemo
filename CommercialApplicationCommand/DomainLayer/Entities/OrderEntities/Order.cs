using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities.States;

namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities
{
    public class Order : Entity
    {
        public IOrderState State { get; set; }

        public Order()
        {
            this.State = new NotSynchronizedState();
        }

        public void SetOrderState(bool IsSynchronized) =>
         this.State.NextState(IsSynchronized);
    }
}