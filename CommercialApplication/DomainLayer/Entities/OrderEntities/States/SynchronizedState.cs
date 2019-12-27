namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities.States
{
    public class SynchronizedState : IOrderState
    {
        public IOrderState NextState(bool IsSynchronized)
        {
            return this;
        }
    }
}