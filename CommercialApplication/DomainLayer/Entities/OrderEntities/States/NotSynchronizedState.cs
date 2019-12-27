namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities.States
{
    public class NotSynchronizedState : IOrderState
    {
        public IOrderState NextState(bool IsSynchronized)
        {
            return IsSynchronized ? (IOrderState)new SynchronizedState() : this;
        }
    }
}