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
    public class CustomerContactControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private IEnumerable<CustomerContactDto> data;
        private IEnumerable<CustomerDto> customerData;
        private CustomerControllerUrls customerControllerUrls;
        private ContactControllerUrls contactControllerUrls;
        private CustomerContactControllerUrls customerContactControllerUrls;
        private CustomerData testCustomer;
        private ContactData testContact;
        private CustomerContactData testCustomerContact;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.customerContactControllerUrls = new CustomerContactControllerUrls();
            this.contactControllerUrls = new ContactControllerUrls();
            this.customerControllerUrls = new CustomerControllerUrls();
            this.testContact = new ContactData();
            this.testCustomer = new CustomerData();
            this.testCustomerContact = new CustomerContactData();
        }

        private IEnumerable<CustomerDto> GetAllCustomersFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CustomerDto>(GetAllData.Customer);
            }
        }

        private IEnumerable<ContactDto> GetAllContactsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ContactDto>(GetAllData.Contact);
            }
        }

        private IEnumerable<CustomerContactDto> GetAllCustomerContactsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CustomerContactDto>(GetAllData.CustomerContact);
            }
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.CustomerContact);
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.CustomerLocation);
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.OrderCustomer);
                connection.Execute(Clean.ProductStorage);
                connection.Execute(Clean.Product);
                connection.Execute(Clean.Action);
                connection.Execute(Clean.Customer);
                connection.Execute(Clean.Contact);
            }
            // Act
            this.apiCaller.Post(this.customerControllerUrls.Url, this.testCustomer.SampleCreate);
            this.customerData = GetAllCustomersFromDatabase();
            this.testContact.SampleCreate.CustomerId = this.customerData.First().Id;
            this.apiCaller.Post(this.contactControllerUrls.Url, this.testContact.SampleCreate);
            this.testCustomerContact.SampleCreate.CustomerId = this.customerData.First().Id;
            this.testCustomerContact.SampleCreate.ContactId = this.GetAllContactsFromDatabase().First().Id;
            this.apiCaller.Post(this.customerContactControllerUrls.Url, this.testCustomerContact.SampleCreate);
            this.data = GetAllCustomerContactsFromDatabase();
            // Assert
            Assert.IsNotEmpty(this.data.ToList());
        }

        [Test, Order(2)]
        public void Delete()
        {
            // Arrange
            this.testContact.SampleDelete.Id = this.GetAllContactsFromDatabase().First().Id;
            this.apiCaller.Delete(this.contactControllerUrls.Url, this.testContact.SampleDelete);
            this.testCustomer.SampleDelete.Id = this.customerData.First().Id;
            this.apiCaller.Delete(this.customerControllerUrls.Url, this.testCustomer.SampleDelete);
            this.testCustomerContact.SampleDelete.CustomerId = this.testCustomer.SampleDelete.Id;
            this.testCustomerContact.SampleDelete.ContactId = this.testContact.SampleDelete.Id;
            // Act
            this.apiCaller.Delete(this.customerContactControllerUrls.Url, this.testCustomerContact.SampleDelete);
            this.data = this.GetAllCustomerContactsFromDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
        }
    }
}
