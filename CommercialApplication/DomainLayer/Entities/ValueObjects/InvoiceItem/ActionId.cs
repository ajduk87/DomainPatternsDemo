namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.InvoiceItem
{
    public class ActionId : ValueObject
    {
        public long Content { get; set; }

        public ActionId(long Content)
        {
            this.Content = Content;
        }

        public static explicit operator ActionId(long actionId)
        {
            return new ActionId(actionId);
        }

        public static implicit operator long(ActionId actionId)
        {
            return actionId.Content;
        }
    }
}