using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Location;
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
    public class CustomerLocationControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private CustomerLocationControllerUrls customerLocationControllerUrls;
        private CustomerControllerUrls customerControllerUrls;
        private LocationControllerUrls locationControllerUrls;
        private CustomerLocationData testCustomerLocation;
        private CustomerData testCustomer;
        private LocationData testLocation;
        private IEnumerable<CustomerLocationDto> customerLocationData;
        private IEnumerable<CustomerDto> customerData;
        private IEnumerable<LocationDto> locationData;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.customerLocationControllerUrls = new CustomerLocationControllerUrls();
            this.customerControllerUrls = new CustomerControllerUrls();
            this.locationControllerUrls = new LocationControllerUrls();
            this.testCustomer = new CustomerData();
            this.testLocation = new LocationData();
            this.testCustomerLocation = new CustomerLocationData();
        }

        public IEnumerable<CustomerDto> GetAllCustomersFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CustomerDto>(GetAllData.Customer);
            }
        }

        public IEnumerable<LocationDto> GetAllLocationsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<LocationDto>(GetAllData.Location);
            }
        }

        public IEnumerable<CustomerLocationDto> GetAllCustomerLocationsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CustomerLocationDto>(GetAllData.Customer);
            }
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using(NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.CustomerLocation);
                connection.Execute(Clean.CustomerContact);
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.OrderCustomer);
                connection.Execute(Clean.Action);
                connection.Execute(Clean.Customer);
                connection.Execute(Clean.Location);
            }
            this.apiCaller.Post(this.customerControllerUrls.Url, this.testCustomer.SampleCreate);
            this.customerData = this.GetAllCustomersFromDatabase();
            this.apiCaller.Post(this.locationControllerUrls.Url, this.testLocation.SampleCreate);
            this.locationData = this.GetAllLocationsFromDatabase();
            this.testCustomerLocation.SampleCreate.CustomerId = this.customerData.First().Id;
            this.testCustomerLocation.SampleCreate.LocationId = this.locationData.First().Id;
            // Act
            this.apiCaller.Post(this.customerLocationControllerUrls.Url, this.testCustomerLocation.SampleCreate);
            this.customerLocationData = this.GetAllCustomerLocationsFromDatabase();
            // Assert
            Assert.IsNotEmpty(this.customerLocationData.ToList());
        }

        [Test, Order(2)]
        public void Delete()
        {
            // Arrange
            this.testCustomer.SampleDelete.Id = this.customerData.First().Id;
            this.testLocation.SampleDelete.Id = this.locationData.First().Id;
            this.testCustomerLocation.SampleDelete.CustomerId = this.customerData.First().Id;
            this.testCustomerLocation.SampleDelete.LocationId = this.locationData.First().Id;
            // Act
            this.apiCaller.Delete(this.customerLocationControllerUrls.Url, this.testCustomerLocation.SampleDelete);
            this.apiCaller.Delete(this.locationControllerUrls.Url, this.testLocation.SampleDelete);
            this.apiCaller.Delete(this.customerControllerUrls.Url, this.testCustomer.SampleDelete);
            this.customerLocationData = this.GetAllCustomerLocationsFromDatabase();
            // Assert
            Assert.IsEmpty(this.customerLocationData.ToList());
        }
    }
}
