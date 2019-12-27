using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.SalesChannel;
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
    class CustomerSalesChannelControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private CustomerData customerData;
        private SalesChannelData salesChannelData;
        private CustomerControllerUrls customerControllerUrls;
        private SalesChannelControllerUrls salesChannelControllerUrls;
        private CustomerSalesChannelControllerUrls customerSalesChannelControllerUrls;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private CustomerSalesChannelData test;
        private IEnumerable<CustomerSalesChannelDto> data;

        private IEnumerable<CustomerDto> GetAllCustomersFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CustomerDto>(GetAllData.Customer);
            }
        }

        private IEnumerable<SalesChannelDto> GetAllSalesChannelsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<SalesChannelDto>(GetAllData.SalesChannel);
            }
        }

        private IEnumerable<CustomerSalesChannelDto> GetAllCustomerSalesChannelsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CustomerSalesChannelDto>(GetAllData.CustomerSalesChannel);
            }
        }

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.customerSalesChannelControllerUrls = new CustomerSalesChannelControllerUrls();
            this.customerControllerUrls = new CustomerControllerUrls();
            this.salesChannelControllerUrls = new SalesChannelControllerUrls();
            this.customerData = new CustomerData();
            this.salesChannelData = new SalesChannelData();
            this.test = new CustomerSalesChannelData();
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.Action);
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.CustomerContact);
                connection.Execute(Clean.CustomerLocation);
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.OrderCustomer);
                connection.Execute(Clean.Customer);
                connection.Execute(Clean.SalesChannel);
            }

            // Act
            this.apiCaller.Post(this.customerControllerUrls.Url, this.customerData.SampleCreate);
            this.apiCaller.Post(this.salesChannelControllerUrls.Url, this.salesChannelData.SampleCreate);
            this.test.SampleCreate.CustomerId = GetAllCustomersFromDatabase().First().Id;
            this.test.SampleCreate.SalesChannelId = GetAllSalesChannelsFromDatabase().First().Id;
            this.apiCaller.Post(this.customerSalesChannelControllerUrls.Url, this.test.SampleCreate);
            this.data = this.GetAllCustomerSalesChannelsFromDatabase();
            // Assert
            Assert.IsNotEmpty(this.data.ToList());
        }

        [Test, Order(2)]
        public void Delete()
        {
            // Arrange
            this.test.SampleDelete.CustomerId = this.data.First().CustomerId;
            this.test.SampleDelete.SalesChannelId = this.data.First().SalesChannelId;
            // Act
            this.apiCaller.Delete(this.customerSalesChannelControllerUrls.Url, this.test.SampleDelete);
            this.data = this.GetAllCustomerSalesChannelsFromDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
        }

        
    }
}
