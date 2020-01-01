using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Repositories.ActionRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.OrderRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Services.OrderServices
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository orderItemRepository;
        private readonly IActionRepository actionRepository;
        private readonly IProductRepository productRepository;

        public OrderItemService()
        {
            this.orderItemRepository = RepositoryFactory.CreateOrderItemRepository();
            this.actionRepository = RepositoryFactory.CreateActionRepository();
            this.productRepository = RepositoryFactory.CreateProductRepository();
        }

        public OrderItem SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.orderItemRepository.SelectById(connection, id);
        }

        public IEnumerable<OrderItem> SelectByIds(IDbConnection connection, IEnumerable<long> ids, IDbTransaction transaction = null)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (long id in ids)
            {
                OrderItem orderItem = this.orderItemRepository.SelectById(connection, id);
                orderItems.Add(orderItem);
            }
            return orderItems;
        }

        public long Insert(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            return this.orderItemRepository.Insert(connection, orderItem);
        }

        public void Update(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            this.orderItemRepository.Update(connection, orderItem);
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            this.orderItemRepository.Delete(connection, id);
        }

        public Money IncludeBasicDiscountForPaying(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            ActionEntity action = this.actionRepository.SelectById(connection, orderItem.ActionId.Content);
            Id id = new Id(orderItem.ProductId);
            double unitCost = this.productRepository.SelectById(connection, id).UnitCost.Value;
            return orderItem.Amount.Content > action.ThresholdAmount ? new Money { Value = orderItem.Amount * unitCost * orderItem.DiscountBasic } : new Money { Value = orderItem.Amount * unitCost };
        }

        public Money IncludeActionDiscountForPaying(IDbConnection connection, OrderItem orderItem, IDbTransaction transaction = null)
        {
            ActionEntity action = this.actionRepository.SelectById(connection, orderItem.ActionId.Content);
            Id id = new Id(orderItem.ProductId);
            double unitCost = this.productRepository.SelectById(connection, id).UnitCost.Value;
            return orderItem.Amount.Content > action.ThresholdAmount ? new Money { Value = orderItem.Amount * unitCost * action.Discount } : new Money { Value = orderItem.Amount * unitCost };
        }
    }
}