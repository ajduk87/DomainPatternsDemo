using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
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
    public class CustomerControllerTest : TestBase
    {
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private CustomerData test;
        private RegistrationAppServices registrationAppServices;
        private CustomerControllerUrls customerControllerUrls;
        private DatabaseParameters databaseParameters;
        private IEnumerable<CustomerDto> data;

        [SetUp]
        public void Setup()
        {
            this.customerControllerUrls = new CustomerControllerUrls();
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseParameters = new DatabaseParameters();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();

            this.test = new CustomerData();
        }

        private IEnumerable<CustomerDto> GetAllDataInDatabase()
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
                connection.Execute(Clean.CustomerLocation);
                connection.Execute(Clean.CustomerContact);
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.OrderCustomer);
                connection.Execute(Clean.Customer);
            }
            // Act
            this.apiCaller.Post(this.customerControllerUrls.Url, this.test.SampleCreate);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsNotEmpty(this.data.ToList());
        }

        [Test, Order(2)]
        public void Put()
        {
            // Arrange
            this.test.SampleUpdate.Id = this.data.First().Id;
            // Act
            this.apiCaller.Put(this.customerControllerUrls.Url, this.test.SampleUpdate);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.AreEqual(this.test.SampleUpdate.Name, this.data.First().Name);
        }

        [Test, Order(3)]
        public void Delete()
        {
            // Arrange
            this.test.SampleDelete.Id = this.data.First().Id;
            // Act 
            this.apiCaller.Delete(this.customerControllerUrls.Url, this.test.SampleDelete);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
        }
    }
}
