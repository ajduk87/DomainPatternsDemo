using CommercialApplication.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.OrderItemOrder;
using CommercialApplicationCommand.DomainLayer.Repositories.ActionRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
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
        private readonly IOrderCustomerRepository orderCustomerRepository;

        private readonly IActionRepository actionRepository;
        private readonly IProductRepository productRepository;

        //private readonly IOrderCustomerService orderCustomerService;
        //private readonly IOrderItemService orderItemService;
        //private readonly IOrderItemOrderService orderItemOrderService;

        public OrderService()
        {
            this.orderRepository = RepositoryFactory.CreateOrderRepository();
            //this.orderItemRepository = RepositoryFactory.CreateOrderItemRepository();
            //this.orderItemOrderRepository = RepositoryFactory.CreateOrderItemOrderRepository();
            //this.orderCustomerRepository = RepositoryFactory.CreateOrderCustomerRepository();

            this.actionRepository = RepositoryFactory.CreateActionRepository();
            this.productRepository = RepositoryFactory.CreateProductRepository();

            //this.orderCustomerService = new OrderCustomerService();
            //this.orderItemService = new OrderItemService();
            //this.orderItemOrderService = new OrderItemOrderService();
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

        private Money IncludeBasicDiscountForPayingOneItem(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            Action action = this.actionRepository.SelectById(connection, orderItem.ActionId.Content);
            Id id = new Id(orderItem.ProductId);
            double unitCost = this.productRepository.SelectById(connection, id).UnitCost.Value;
            return orderItem.Amount.Content > action.ThresholdAmount ? new Money { Value = orderItem.Amount * unitCost * orderItem.DiscountBasic } : new Money { Value = orderItem.Amount * unitCost };
        }

        private Money IncludeActionDiscountForPayingOneItem(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            Action action = this.actionRepository.SelectById(connection, orderItem.ActionId.Content);
            Id id = new Id(orderItem.ProductId);
            double unitCost = this.productRepository.SelectById(connection, id).UnitCost.Value;
            return orderItem.Amount.Content > action.ThresholdAmount ? new Money { Value = orderItem.Amount * unitCost * action.Discount } : new Money { Value = orderItem.Amount * unitCost };
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
                //OrderItem orderItem = this.orderItemRepository.SelectById(connection, id);
                OrderItem orderItem = this.orderRepository.SelectOrderItemById(connection, id);
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
                    //OrderItem orderItem = this.orderItemRepository.SelectById(connection, id);
                    OrderItem orderItem = this.orderRepository.SelectOrderItemById(connection, id);
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
                //OrderItem orderItem = this.orderItemRepository.SelectById(connection, id);
                OrderItem orderItem = this.orderRepository.SelectOrderItemById(connection, id);
                orderItems.Add(orderItem);
            }
            double firstOrderSumValue = this.SumValue(connection, orderItems);


            long orderIdWithMinSumValue = orderItemsIds.First();
            double orderMinSumValue = firstOrderSumValue;


            for (int i = 1; i < orders.Count(); i++)
            {
                double currentOrderSumValue = 0;
                //IEnumerable<long> orderItemsIdsForCurrentOrder = this.orderItemOrderRepository.SelectByOrderId(connection, orders.First().Id);
                IEnumerable<long> orderItemsIdsForCurrentOrder = this.orderRepository.SelectOrderItemsIdsByOrderId(connection, orders.First().Id);
                List <OrderItem> orderItemsForCurrentOrder = new List<OrderItem>();
                foreach (long id in orderItemsIds)
                {
                    //OrderItem orderItem = this.orderItemRepository.SelectById(connection, id);
                    OrderItem orderItem = this.orderRepository.SelectOrderItemById(connection, id);
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
            order.State = orderState.State;
            this.orderRepository.Update(connection, order, transaction);
        }

        //OrderCustomer
        public Customer SelectOrderCustomerByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            //return this.orderCustomerService.SelectByOrderId(connection, id, transaction);
            //return this.orderCustomerRepository.SelectByOrderId(connection, id);
            return this.orderRepository.SelectCustomerByOrderId(connection, id);
        }
        public void InsertOrderCustomer(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null) =>
            //this.orderCustomerService.Insert(connection, orderCustomer, transaction);
            //this.orderCustomerRepository.Insert(connection, orderCustomer);
            this.orderRepository.InsertCustomerForOrder(connection, orderCustomer);

        public void DeleteOrderCustomer(IDbConnection connection, long id, IDbTransaction transaction = null) =>
            //this.orderCustomerService.Delete(connection, id, transaction);
            //this.orderCustomerRepository.Delete(connection, id);
            this.orderRepository.DeleteCustomerForOrder(connection, id);

        public void UpdateOrderCustomer(IDbConnection connection, OrderCustomer orderCustomer, IDbTransaction transaction = null) =>
            //this.orderCustomerService.Update(connection, orderCustomer, transaction);
            //this.orderCustomerRepository.Update(connection, orderCustomer);
            this.orderRepository.UpdateCustomerForOrder(connection, orderCustomer);

        //OrderItem
        public OrderItem SelectOrderItemById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            //return this.orderItemService.SelectById(connection, id, transaction);
            //return this.orderItemRepository.SelectById(connection, id);
            return this.orderRepository.SelectOrderItemById(connection, id);
        }
        public IEnumerable<OrderItem> SelectOrderItemByIds(IDbConnection connection, IEnumerable<long> ids, IDbTransaction transaction = null)
        {
            //return this.orderItemService.SelectByIds(connection, ids, transaction);
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (long id in ids)
            {
                //OrderItem orderItem = this.orderItemRepository.SelectById(connection, id);
                OrderItem orderItem = this.orderRepository.SelectOrderItemById(connection, id);
                orderItems.Add(orderItem);
            }
            return orderItems;
        }
        public long InsertOrderItem(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            //return this.orderItemService.Insert(connection, orderItem, transaction);
            //return this.orderItemRepository.Insert(connection, orderItem);
            return this.orderRepository.InsertOrderItem(connection, orderItem);
        }
        public void InsertListOrderItem(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null) /*=>*/
            //this.orderItemService.InsertList(connection, orderItems, transaction);
        {
            foreach (OrderItem orderItem in orderItems)
            {
                //this.orderItemRepository.Insert(connection, orderItem);
                this.orderRepository.InsertOrderItem(connection, orderItem);
            }
        }

        public void UpdateOrderItem(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)=>
            //this.orderItemService.Update(connection, orderItem, transaction);
            //this.orderItemRepository.Update(connection, orderItem);
            this.orderRepository.UpdateOrderItem(connection, orderItem);

        public void UpdateOrderItemList(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null) //=>
           //this.orderItemService.UpdateList(connection, orderItems, transaction);
        {
            foreach (OrderItem orderItem in orderItems)
            {
                //this.orderItemRepository.Update(connection, orderItem);
                this.orderRepository.UpdateOrderItem(connection, orderItem);
            }
        }

        public void DeleteOrderItem(IDbConnection connection, long id, IDbTransaction transaction = null) =>
           //this.orderItemService.Delete(connection, id, transaction);
           //this.orderItemRepository.Delete(connection, id);
           this.orderRepository.DeleteOrderItem(connection, id);

        public void DeleteOrderItemByIds(IDbConnection connection, IEnumerable<long> ids, IDbTransaction transaction = null) //=>
           //this.orderItemService.DeleteByIds(connection, ids, transaction);
        {
            foreach (long id in ids)
            {
                //this.orderItemRepository.Delete(connection, id);
                this.orderRepository.DeleteOrderItem(connection, id);
            }
        }

        public IEnumerable<OrderItem> IncludeBasicDiscountForPaying(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null)
        {
            //return this.orderItemService.IncludeBasicDiscountForPaying(connection, orderItems, transaction);
            List<OrderItem> calculatedOrderItems = new List<OrderItem>();
            foreach (OrderItem orderItem in orderItems)
            {
                OrderItem calculatedOrderItem = new OrderItem();
                calculatedOrderItem.Value = this.IncludeBasicDiscountForPayingOneItem(connection, orderItem);
                calculatedOrderItems.Add(calculatedOrderItem);
            }
            return calculatedOrderItems;
        }
        public IEnumerable<OrderItem> IncludeActionDiscountForPaying(IDbConnection connection, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null)
        {
            //return this.orderItemService.IncludeActionDiscountForPaying(connection, orderItems, transaction);
            List<OrderItem> calculatedOrderItems = new List<OrderItem>();
            foreach (OrderItem orderItem in orderItems)
            {
                OrderItem calculatedOrderItem = new OrderItem();
                calculatedOrderItem.Value = this.IncludeActionDiscountForPayingOneItem(connection, orderItem);
                calculatedOrderItems.Add(calculatedOrderItem);
            }
            return calculatedOrderItems;
        }

        //OrderItemOrder
        public void InsertOrderItemOrder(IDbConnection connection, OrderItemOrder orderItemOrder, IDbTransaction transaction = null) =>
            //this.orderItemOrderService.Insert(connection, orderItemOrder, transaction);
            //this.orderItemOrderRepository.Insert(connection, orderItemOrder);
            this.orderRepository.InsertOrderItemOrder(connection, orderItemOrder);

        public void InsertOrderItemOrderList(IDbConnection connection, IEnumerable<OrderItem> orderItems, long orderId, IDbTransaction transaction = null) //=>
            //this.orderItemOrderService.InsertList(connection, orderItems, orderId, transaction);
        {
            foreach (OrderItem orderItem in orderItems)
            {
                OrderItemOrder orderItemOrder = new OrderItemOrder
                {
                    OrderItemId = new OrderItemId(orderItem.Id),
                    OrderId = new OrderId(orderId)
                };
                //this.orderItemOrderRepository.Insert(connection, orderItemOrder);
                this.orderRepository.InsertOrderItemOrder(connection, orderItemOrder);
            }
        }
        public void DeleteOrderItemOrder(IDbConnection connection, long id, IDbTransaction transaction = null) =>
            //this.orderItemOrderService.Delete(connection, id, transaction);
            //this.orderItemOrderRepository.Delete(connection, id);
            this.orderRepository.DeleteOrderItemOrder(connection, id);

        public IEnumerable<long> SelectOrderItemOrderByOrderId(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            //return this.orderItemOrderService.SelectByOrderId(connection, id, transaction);
            //return this.orderItemOrderRepository.SelectByOrderId(connection, id);
            return this.orderRepository.SelectOrderItemsIdsByOrderId(connection, id);
        }
    }
}