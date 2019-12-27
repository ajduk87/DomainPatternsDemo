using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Order;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Services.OrderServices;
using Npgsql;
using System;
using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Services.OrderServices
{
    public class OrderAppService : BaseAppService, IOrderAppService
    {
        private readonly IOrderCustomerService orderCustomerService;
        private readonly IOrderItemOrderService orderItemOrderService;
        private readonly IOrderItemService orderItemService;
        private readonly IOrderService orderService;

        public OrderAppService()
        {
            this.orderService = this.registrationServices.Instance.Container.Resolve<IOrderService>();
            this.orderItemService = this.registrationServices.Instance.Container.Resolve<IOrderItemService>();
            this.orderCustomerService = this.registrationServices.Instance.Container.Resolve<IOrderCustomerService>();
            this.orderItemOrderService = this.registrationServices.Instance.Container.Resolve<IOrderItemOrderService>();
        }

        public void CreateNewOrder(OrderDto orderDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        Order order = this.dtoToEntityMapper.Map<OrderDto, Order>(orderDto);
                        long orderId = this.orderService.Insert(connection, order);
                        OrderCustomerDto orderCustomerDto = new OrderCustomerDto
                        {
                            CustomerId = orderDto.CustomerId,
                            OrderId = orderId
                        };
                        OrderCommercialistDto orderCommercialistDto = new OrderCommercialistDto
                        {
                            OrderId = orderId,
                            CommercialistId = orderDto.CommercialistId
                        };
                        OrderCustomer orderCustomer = this.dtoToEntityMapper.Map<OrderCustomerDto, OrderCustomer>(orderCustomerDto);
                        OrderCommercialist orderCommercialist = this.dtoToEntityMapper.Map<OrderCommercialistDto, OrderCommercialist>(orderCommercialistDto);
                        this.orderCustomerService.Insert(connection, orderCustomer);
                        foreach (OrderItemDto orderItemDto in orderDto.orderItems)
                        {
                            OrderItem orderItem = this.dtoToEntityMapper.Map<OrderItemDto, OrderItem>(orderItemDto);
                            orderItem.Value = this.orderItemService.IncludeBasicDiscountForPaying(connection, orderItem);
                            orderItem.Value = this.orderItemService.IncludeActionDiscountForPaying(connection, orderItem);
                            long orderItemId = this.orderItemService.Insert(connection, orderItem);
                            OrderItemOrderDto orderItemOrderDto = new OrderItemOrderDto
                            {
                                OrderId = orderId,
                                OrderItemId = orderItemId
                            };
                            OrderItemOrder orderItemOrder = this.dtoToEntityMapper.Map<OrderItemOrderDto, OrderItemOrder>(orderItemOrderDto);
                            this.orderItemOrderService.Insert(connection, orderItemOrder);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.Write(ex.Message);
                    }
                }
            }
        }

        public void UpdateExistingOrder(OrderDto orderDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        OrderCustomerDto orderCustomerDto = new OrderCustomerDto
                        {
                            OrderId = orderDto.Id,
                            CustomerId = orderDto.CustomerId
                        };
                        OrderCommercialistDto orderCommercialistDto = new OrderCommercialistDto
                        {
                            OrderId = orderDto.Id,
                            CommercialistId = orderDto.CommercialistId
                        };
                        OrderCustomer orderCustomer = this.dtoToEntityMapper.Map<OrderCustomerDto, OrderCustomer>(orderCustomerDto);
                        OrderCommercialist orderCommercialist = this.dtoToEntityMapper.Map<OrderCommercialistDto, OrderCommercialist>(orderCommercialistDto);
                        this.orderCustomerService.Update(connection, orderCustomer);
                        foreach (OrderItemDto orderItemDto in orderDto.orderItems)
                        {
                            OrderItem orderItem = this.dtoToEntityMapper.Map<OrderItemDto, OrderItem>(orderItemDto);
                            orderItem.Value = this.orderItemService.IncludeBasicDiscountForPaying(connection, orderItem);
                            orderItem.Value = this.orderItemService.IncludeActionDiscountForPaying(connection, orderItem);
                            this.orderItemService.Update(connection, orderItem);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.Write(ex.Message);
                    }
                }
            }
        }

        public void DeleteExistingOrder(long id)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        IEnumerable<long> orderItemIds = this.orderItemOrderService.SelectByOrderId(connection, id);
                        this.orderItemOrderService.Delete(connection, id);
                        this.orderCustomerService.Delete(connection, id);
                        foreach (long orderItemId in orderItemIds)
                        {
                            this.orderItemService.Delete(connection, orderItemId);
                        }
                        this.orderService.Delete(connection, id);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.Write(ex.Message);
                    }
                }
            }
        }
    }
}