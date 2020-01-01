using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService()
        {
            this.orderRepository = RepositoryFactory.CreateOrderRepository();
        }

        public Order SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.orderRepository.SelectById(connection, id);
        }

        public IEnumerable<Order> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null)
        {
            return this.orderRepository.SelectByDay(connection, day);
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            this.orderRepository.Delete(connection, id);
        }

        public long Insert(IDbConnection connection, Order order, IDbTransaction transaction = null)
        {
            return this.orderRepository.Insert(connection, order);
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.orderRepository.Exists(connection, id);
        }

        public void Update(IDbConnection connection, Order order, IDbTransaction transaction = null)
        {
            this.orderRepository.Update(connection, order);
        }

        public double SumValue(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null)
        {
            double orderSumValue = 0;
            foreach (OrderItem orderitem in orderItems)
            {
                orderSumValue = orderSumValue + orderitem.Value.Value;
            }
            return orderSumValue;
        }
    }
}