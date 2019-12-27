namespace CommercialApplicationCommand.DomainLayer.Entities.OrderEntities.States
{
    public interface IOrderState
    {
        IOrderState NextState(bool IsSynchronized);
    }
}