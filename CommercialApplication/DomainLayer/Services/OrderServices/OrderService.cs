using CommercialApplication.DomainLayer.Entities.OrderEntities;
using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderItemRepository orderItemRepository;
        private readonly IOrderItemOrderRepository orderItemOrderRepository;

        public OrderService()
        {
            this.orderRepository = RepositoryFactory.CreateOrderRepository();
            this.orderItemRepository = RepositoryFactory.CreateOrderItemRepository();
            this.orderItemOrderRepository = RepositoryFactory.CreateOrderItemOrderRepository();
        }

        private double SumValue(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null)
        {
            double orderSumValue = 0;
            foreach (OrderItem orderitem in orderItems)
            {
                orderSumValue = orderSumValue + orderitem.Value.Value;
            }
            return orderSumValue;
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

        public long SelectOrderIdWithMaxSumValueByDay(IDbConnection connection, IEnumerable<Order> orders, IDbTransaction transaction = null)
        {
            IEnumerable<long> orderItemsIds = this.orderItemOrderRepository.SelectByOrderId(connection, orders.First().Id);
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (long id in orderItemsIds)
            {
                OrderItem orderItem = this.orderItemRepository.SelectById(connection, id);
                orderItems.Add(orderItem);
            }
            double firstOrderSumValue = this.SumValue(connection, orderItems);


            long orderIdWithMaxSumValue = orderItemsIds.First();
            double orderMaxSumValue = firstOrderSumValue;


            for (int i = 1; i < orders.Count(); i++)
            {
                double currentOrderSumValue = 0;
                IEnumerable<long> orderItemsIdsForCurrentOrder = this.orderItemOrderRepository.SelectByOrderId(connection, orders.First().Id);
                List<OrderItem> orderItemsForCurrentOrder = new List<OrderItem>();
                foreach (long id in orderItemsIds)
                {
                    OrderItem orderItem = this.orderItemRepository.SelectById(connection, id);
                    orderItemsForCurrentOrder.Add(orderItem);
                }
                currentOrderSumValue = this.SumValue(connection, orderItemsForCurrentOrder);

                if (currentOrderSumValue > orderMaxSumValue)
                {
                    orderIdWithMaxSumValue = i;
                    orderMaxSumValue = currentOrderSumValue;
                }
            }
            return orderIdWithMaxSumValue;
        }

        public long SelectOrderIdWithMinSumValueByDay(IDbConnection connection, IEnumerable<Order> orders, IDbTransaction transaction = null)
        {
            IEnumerable<long> orderItemsIds = this.orderItemOrderRepository.SelectByOrderId(connection, orders.First().Id);
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (long id in orderItemsIds)
            {
                OrderItem orderItem = this.orderItemRepository.SelectById(connection, id);
                orderItems.Add(orderItem);
            }
            double firstOrderSumValue = this.SumValue(connection, orderItems);


            long orderIdWithMinSumValue = orderItemsIds.First();
            double orderMinSumValue = firstOrderSumValue;


            for (int i = 1; i < orders.Count(); i++)
            {
                double currentOrderSumValue = 0;
                IEnumerable<long> orderItemsIdsForCurrentOrder = this.orderItemOrderRepository.SelectByOrderId(connection, orders.First().Id);
                List<OrderItem> orderItemsForCurrentOrder = new List<OrderItem>();
                foreach (long id in orderItemsIds)
                {
                    OrderItem orderItem = this.orderItemRepository.SelectById(connection, id);
                    orderItemsForCurrentOrder.Add(orderItem);
                }
                currentOrderSumValue = this.SumValue(connection, orderItemsForCurrentOrder);

                if (currentOrderSumValue < orderMinSumValue)
                {
                    orderIdWithMinSumValue = i;
                    orderMinSumValue = currentOrderSumValue;
                }
            }
            return orderIdWithMinSumValue;
        }

        public void UpdateState(IDbConnection connection, OrderState orderState, IDbTransaction transaction = null)
        {
            Order order = this.orderRepository.SelectById(connection, orderState.Id);            

            this.orderRepository.Update(connection, order.SetState(orderState.State), transaction);
        }
    }
}