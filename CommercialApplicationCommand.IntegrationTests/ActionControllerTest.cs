using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
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
    public class ActionControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private ActionControllerUrls actionControllerUrls;
        private ProductControllerUrls productControllerUrls;
        private CustomerControllerUrls customerControllerUrls;
        private DatabaseParameters databaseParameters;
        private IEnumerable<ActionDto> data;
        private ProductEntityTest testProduct;
        private CustomerData testCustomer;
        private ActionData testAction;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.productControllerUrls = new ProductControllerUrls();
            this.actionControllerUrls = new ActionControllerUrls();
            this.customerControllerUrls = new CustomerControllerUrls();
            this.testAction = new ActionData();
            this.testCustomer = new CustomerData();
            this.testProduct = new ProductEntityTest();
        }

        private IEnumerable<ActionDto> GetAllActionsFromDatabase()
        {
            using(NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ActionDto>(GetAllData.Action);
            }
        }

        private IEnumerable<ProductDtoTest> GetAllProductsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ProductDtoTest>(GetAllData.Product);
            }
        }

        private IEnumerable<CustomerDto> GetAllCustomersFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CustomerDto>(GetAllData.Customer);
            }
        }


        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.CustomerLocation);
                connection.Execute(Clean.CustomerContact);
                connection.Execute(Clean.Customer);
                connection.Execute(Clean.Product);
                connection.Execute(Clean.Action);
            }
            // Act
            this.apiCaller.Post(this.productControllerUrls.Url, this.testProduct.SampleCreate);
            this.testAction.SampleCreate.ProductId = this.GetAllProductsFromDatabase().First().Id;
            this.apiCaller.Post(this.customerControllerUrls.Url, this.testCustomer.SampleCreate);
            this.testAction.SampleCreate.CustomerId = this.GetAllCustomersFromDatabase().First().Id;
            this.apiCaller.Post(this.actionControllerUrls.Url, this.testAction.SampleCreate);
            this.data = this.GetAllActionsFromDatabase();
            // Assert
            Assert.IsNotEmpty(this.data.ToList());
        }

        [Test, Order(2)]
        public void PutOnCustomerEndpoint()
        {
            // Arrange
            this.testAction.SampleUpdate.ProductId = this.data.First().ProductId;
            this.testAction.SampleUpdate.CustomerId = this.data.First().CustomerId;
            this.testAction.SampleUpdate.Id = this.data.First().Id;
            // Act
            this.apiCaller.Put(this.actionControllerUrls.UrlForUpdatingByCustomerId, this.testAction.SampleUpdate);
            this.data = GetAllActionsFromDatabase();
            // Assert
            Assert.AreEqual(this.testAction.SampleUpdate.Discount, this.data.First().Discount);
        }

        [Test, Order(3)]
        public void PutOnSalesChannelEndpoint()
        {
            // Arrange
        }

        [Test, Order(4)]
        public void Delete()
        {
            // Arrange
            this.testAction.SampleDelete.Id = this.data.First().Id;
            // Act
            this.apiCaller.Delete(this.actionControllerUrls.Url, this.testAction.SampleDelete);
            this.data = this.GetAllActionsFromDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
        }
    }
}
