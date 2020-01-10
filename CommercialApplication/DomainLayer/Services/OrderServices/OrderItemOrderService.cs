using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.OrderItemOrder;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public class OrderItemOrderService : IOrderItemOrderService
    {
        private readonly IOrderItemOrderRepository orderItemOrderRepository;

        public OrderItemOrderService()
        {
            this.orderItemOrderRepository = RepositoryFactory.CreateOrderItemOrderRepository();
        }

        public void Insert(IDbConnection connection, OrderItemOrder orderItemOrder, IDbTransaction transaction = null)
        {
            this.orderItemOrderRepository.Insert(connection, orderItemOrder);
        }

        public void InsertList(IDbConnection connection, IEnumerable<OrderItem> orderItems, long orderId, IDbTransaction transaction = null)
        {
            /*foreach (OrderItem orderItem in orderItems)
            {
                OrderItemOrder orderItemOrder = new OrderItemOrder
                {
                    OrderItemId = new OrderItemId(orderItem.Id),
                    OrderId = new OrderId(orderId)
                };
                this.orderItemOrderRepository.Insert(connection, orderItemOrder);
            }*/
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            this.orderItemOrderRepository.Delete(connection, id);
        }

        public IEnumerable<long> SelectByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.orderItemOrderRepository.SelectByOrderId(connection, id);
        }
    }
}