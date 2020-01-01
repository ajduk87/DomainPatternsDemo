using CommercialApplicationCommand.ApplicationLayer.Dtoes.Order;
using System;

namespace CommercialApplicationCommand.ApplicationLayer.Services.OrderServices
{
    public interface IOrderAppService
    {
        OrderDto GetOrder(long id);
        OrderDto GetMaxSumValueOrderForDay(DateTime day);
        OrderDto GetMinSumValueOrderForDay(DateTime day);
        void CreateNewOrder(OrderDto orderDto);

        void UpdateExistingOrder(OrderDto orderDto);

        void DeleteExistingOrder(long id);
    }
}