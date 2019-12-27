using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Contact;
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
    class ContactControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private ContactControllerUrls contactControllerUrls;
        private CustomerControllerUrls customerControllerUrls;
        private ContactData contactTest;
        private CustomerData customerTest;
        private IEnumerable<CustomerDto> customerData;
        private IEnumerable<ContactDto> contactData;

        [SetUp]
        public void SetUp()
        {
            this.contactControllerUrls = new ContactControllerUrls();
            this.customerControllerUrls = new CustomerControllerUrls();
            this.databaseParameters = new DatabaseParameters();
            this.registrationAppServices = new RegistrationAppServices();
            this.contactTest = new ContactData();
            this.customerTest = new CustomerData();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
        }

        IEnumerable<ContactDto> GetAllContactsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ContactDto>(GetAllData.Contact);
            }
        }

        IEnumerable<CustomerDto> GetAllCustomersFromDatabase()
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
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.OrderCustomer);
                connection.Execute(Clean.CustomerContact);
                connection.Execute(Clean.ProductStorage);
                connection.Execute(Clean.Product);
                connection.Execute(Clean.Action);
                connection.Execute(Clean.Contact);
                connection.Execute(Clean.Customer);
            }
            // Act
            this.apiCaller.Post(this.customerControllerUrls.Url, this.customerTest.SampleCreate);
            this.customerData = this.GetAllCustomersFromDatabase();
            this.contactTest.SampleCreate.CustomerId = this.customerData.First().Id;
            this.apiCaller.Post(this.contactControllerUrls.Url, this.contactTest.SampleCreate);
            this.contactData = this.GetAllContactsFromDatabase();
            // Assert
            Assert.IsNotEmpty(this.contactData.ToList());
        }

        [Test, Order(2)]
        public void Put()
        {
            // Arrange
            this.contactTest.SampleUpdate.Id = this.contactData.First().Id;
            // Act
            this.apiCaller.Put(this.contactControllerUrls.Url, this.contactTest.SampleUpdate);
            this.contactData = this.GetAllContactsFromDatabase();
            // Assert
            Assert.AreEqual(this.contactTest.SampleUpdate.Email, this.contactData.First().Email);
            Assert.AreEqual(this.contactTest.SampleUpdate.Phone, this.contactData.First().Phone);
        }

        [Test, Order(3)]
        public void Delete()
        {
            // Arrange
            this.contactTest.SampleDelete.Id = this.contactData.First().Id;
            this.customerTest.SampleDelete.Id = this.customerData.First().Id;
            // Act
            this.apiCaller.Delete(this.customerControllerUrls.Url, this.customerTest.SampleDelete);
            this.apiCaller.Delete(this.contactControllerUrls.Url, this.contactTest.SampleDelete);
            this.contactData = this.GetAllContactsFromDatabase();
            this.customerData = this.GetAllCustomersFromDatabase();
            // Assert
            Assert.IsEmpty(this.customerData.ToList());
            Assert.IsEmpty(this.contactData.ToList());
        }
    }
}
