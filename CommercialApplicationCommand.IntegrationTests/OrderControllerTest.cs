using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Commercialist;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Order;
using CommercialApplicationCommand.ApplicationLayer.Models.Action;
using CommercialApplicationCommand.ApplicationLayer.Models.Order;
using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Registration.Containers;
using CommercialApplicationCommand.IntegrationTests.Setup;
using CommercialApplicationCommand.IntegrationTests.TestsData;
using CommercialApplicationCommand.IntegrationTests.Urls;
using Dapper;
using Npgsql;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests
{
    public class OrderControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private OrderControllerUrls orderControllerUrls;
        private OrderData testOrder;
        private ProductDataForOrderAndInvoiceTesting productDataForOrderTesting;
        private CustomerControllerUrls customerControllerUrls;
        private ProductControllerUrls productControllerUrls;
        private CommercialistControllerUrls commercialistControllerUrls;
        private CustomerData testCustomer;
        private CommercialistData testCommercialist;
        private ActionControllerUrls actionControllerUrls;
        private Random numberGenerator;
        private IEnumerable<OrderDto> orderData;
        private IEnumerable<ActionDto> actionData;
        private IEnumerable<ProductDtoTest> productData;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.orderControllerUrls = new OrderControllerUrls();
            this.productControllerUrls = new ProductControllerUrls();
            this.customerControllerUrls = new CustomerControllerUrls();
            this.commercialistControllerUrls = new CommercialistControllerUrls();
            this.productDataForOrderTesting = new ProductDataForOrderAndInvoiceTesting();
            this.actionControllerUrls = new ActionControllerUrls();
            this.testOrder = new OrderData();
            this.testCustomer = new CustomerData();
            this.testCommercialist = new CommercialistData();
            this.numberGenerator = new Random();
        }

        private IEnumerable<ProductDtoTest> GetAllProductsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ProductDtoTest>(GetAllData.Product);
            }
        }

        private IEnumerable<ActionDto> GetAllActionsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ActionDto>(GetAllData.Action);
            }
        }

        private IEnumerable<CustomerDto> GetAllCustomersFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CustomerDto>(GetAllData.Customer);
            }
        }

        private IEnumerable<CommercialistDto> GetAllCommercialistsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CommercialistDto>(GetAllData.Commercialist);
            }
        }

        private IEnumerable<OrderDto> GetAllOrdersFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<OrderDto>(GetAllData.Order);
            }
        }

        private IEnumerable<OrderItemDto> GetAllOrderItemsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<OrderItemDto>(GetAllData.OrderItem);
            }
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.OrderItemOrder);
                connection.Execute(Clean.OrderCustomer);
                connection.Execute(Clean.OrderItem);
                connection.Execute(Clean.InvoiceCommercialist);
                connection.Execute(Clean.CommercialistLocation);
                connection.Execute(Clean.OrderCommercialist);
                connection.Execute(Clean.Order);
                connection.Execute(Clean.Action);
                connection.Execute(Clean.ProductStorage);
                connection.Execute(Clean.Product);
                connection.Execute(Clean.CustomerLocation);
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.CustomerContact);
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.OrderCustomer);
                connection.Execute(Clean.Customer);
                connection.Execute(Clean.Commercialist);
            }
            this.apiCaller.Post(this.customerControllerUrls.Url, this.testCustomer.SampleCreate);
            long customerId = GetAllCustomersFromDatabase().First().Id;
            foreach (ProductCreateModel product in this.productDataForOrderTesting.Products)
            {
                this.apiCaller.Post(this.productControllerUrls.Url, product);
                ActionCreateModel action = new ActionCreateModel
                {
                    Discount = this.numberGenerator.NextDouble(),
                    ProductId = this.GetAllProductsFromDatabase().Where(p => p.Name == product.Name).First().Id,
                    CustomerId = customerId,
                    ThresholdAmount = this.numberGenerator.Next(10, 90)
                };
                this.apiCaller.Post(this.actionControllerUrls.Url, action);
            }
            this.apiCaller.Post(this.commercialistControllerUrls.Url, this.testCommercialist.SampleCreate);
            this.productData = this.GetAllProductsFromDatabase();
            this.actionData = this.GetAllActionsFromDatabase();
            this.testOrder.SampleCreate.CustomerId = customerId;
            this.testOrder.SampleCreate.CommercialistId = GetAllCommercialistsFromDatabase().First().Id;
            using (var order = this.testOrder.SampleCreate.orderItems.GetEnumerator()) 
            using (var product = this.productData.GetEnumerator())
            {
                while(order.MoveNext() && product.MoveNext())
                {
                    order.Current.ProductId = product.Current.Id;
                    order.Current.ActionId = this.actionData.Where(a => a.ProductId == product.Current.Id).First().Id;
                }
            }
            // Act
            this.apiCaller.Post(this.orderControllerUrls.Url, this.testOrder.SampleCreate);
            this.orderData = GetAllOrdersFromDatabase();
            this.orderData.First().orderItems = GetAllOrderItemsFromDatabase();
            // Assert
            Assert.IsNotEmpty(this.orderData.ToList());
        }

        [Test, Order(2)]
        public void Put()
        {
            // Arrange
            using(var orderItemsFromData = this.orderData.First().orderItems.GetEnumerator())
            using(var productForUpdate = this.testOrder.SampleUpdate.orderItems.GetEnumerator())
            {
                while(orderItemsFromData.MoveNext() && productForUpdate.MoveNext())
                {
                    productForUpdate.Current.Id = orderItemsFromData.Current.Id;
                    productForUpdate.Current.ProductId = orderItemsFromData.Current.ProductId;
                    productForUpdate.Current.ActionId = orderItemsFromData.Current.ActionId;
                }
            }
            this.testOrder.SampleUpdate.Id = this.GetAllOrdersFromDatabase().First().Id;
            this.testOrder.SampleUpdate.CustomerId = this.GetAllCustomersFromDatabase().First().Id;
            this.testOrder.SampleUpdate.CommercialistId = this.GetAllCommercialistsFromDatabase().First().Id;
            // Act
            this.apiCaller.Put(this.orderControllerUrls.Url, this.testOrder.SampleUpdate);
            this.orderData = this.GetAllOrdersFromDatabase();
            this.orderData.First().orderItems = this.GetAllOrderItemsFromDatabase();
            // Assert
            foreach(OrderItemUpdateModel sampleOrderItem in this.testOrder.SampleUpdate.orderItems)
            {
                Assert.AreEqual(sampleOrderItem.Amount, this.orderData.First().orderItems.Where(oi => oi.Id == sampleOrderItem.Id).First().Amount);
                Assert.AreEqual(sampleOrderItem.DiscountBasic , this.orderData.First().orderItems.Where(oi => oi.Id == sampleOrderItem.Id).First().DiscountBasic);
            }
        }

        [Test, Order(3)]
        public void Delete()
        {
            // Arrange
            this.testOrder.SampleDelete.Id = this.orderData.First().Id;
            // Act
            this.apiCaller.Delete(this.orderControllerUrls.Url, this.testOrder.SampleDelete);
            this.orderData = GetAllOrdersFromDatabase();
            // Assert
            Assert.IsEmpty(this.orderData.ToList());
            using(NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.Action);
                connection.Execute(Clean.Product);
                connection.Execute(Clean.Customer);
                connection.Execute(Clean.Commercialist);
            }
        }
    }
}
