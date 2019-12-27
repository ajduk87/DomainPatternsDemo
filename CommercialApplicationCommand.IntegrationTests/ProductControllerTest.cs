using Autofac;
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
    public class ProductControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private ProductControllerUrls productControllerUrls;
        private ProductEntityTest test;
        private IEnumerable<ProductDtoTest> data;

        [SetUp]
        public void Setup()
        {
            this.productControllerUrls = new ProductControllerUrls();
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseParameters = new DatabaseParameters();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();

            this.test = new ProductEntityTest();
        }

        private IEnumerable<ProductDtoTest> GetAllDataInDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ProductDtoTest>(GetAllData.Product);
            }
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using(NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.ProductStorage);
                connection.Execute(Clean.CommercialistLocation);
                connection.Execute(Clean.InvoiceCommercialist);
                connection.Execute(Clean.OrderCommercialist);
                connection.Execute(Clean.Commercialist);
                connection.Execute(Clean.CustomerContact);
                connection.Execute(Clean.CustomerLocation);
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.OrderCustomer);
                connection.Execute(Clean.Action);
                connection.Execute(Clean.Product);
            }
            // Act
            this.apiCaller.Post(this.productControllerUrls.Url, this.test.SampleCreate);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsNotEmpty(data.ToList());
        }

        [Test, Order(2)]
        public void Put()
        {
            // Arrange
            this.data = this.GetAllDataInDatabase();
            this.test.SampleUpdate.Id = data.First().Id;
            // Act
            this.apiCaller.Put(this.productControllerUrls.Url, this.test.SampleUpdate);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.AreEqual(this.test.SampleUpdate.Name, this.data.First().Name);
        }

        [Test, Order(3)]
        public void Delete()
        {
            // Arrange
            this.data = this.GetAllDataInDatabase();
            this.test.SampleDelete.Id = this.data.First().Id;
            // Act
            this.apiCaller.Delete(this.productControllerUrls.Url, this.test.SampleDelete);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
        }
    }
}
