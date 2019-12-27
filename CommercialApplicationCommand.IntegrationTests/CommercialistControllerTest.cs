using CommercialApplicationCommand.IntegrationTests;
using NUnit.Framework;
using Dapper;
using CommercialApplicationCommand.ApplicationLayer.Registration.Containers;
using CommercialApplicationCommand;
using Autofac;
using Npgsql;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.CommercialistRepositories;
using CommercialApplicationCommand.IntegrationTests.Setup;
using CommercialApplicationCommand.IntegrationTests.Urls;
using CommercialApplicationCommand.DomainLayer.Entities.CommercialistEntities;
using CommercialApplicationCommand.ApplicationLayer.Models.Commercialist;
using CommercialApplicationCommand.IntegrationTests.TestsData;
using System.Collections.Generic;
using System.Linq;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Commercialist;

namespace CommercialApplicationCommand.IntegrationTests
{
    public class CommercialistControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private CommercialistControllerUrls commercialistControllerUrls;
        private CommercialistData test;
        private IEnumerable<CommercialistDto> data;


        [SetUp]
        public void Setup()
        {
            this.commercialistControllerUrls = new CommercialistControllerUrls();
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseParameters = new DatabaseParameters();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();

            this.test = new CommercialistData();
        }

        private IEnumerable<CommercialistDto> GetAllDataInDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CommercialistDto>(GetAllData.Commercialist);
            }
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arange            
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.CommercialistLocation);
                connection.Execute(Clean.InvoiceCommercialist);
                connection.Execute(Clean.OrderCommercialist);
                connection.Execute(Clean.Commercialist);
            }
            // Act
            this.apiCaller.Post(this.commercialistControllerUrls.Url, this.test.SampleCreate);
            data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsNotEmpty(data.ToList());
        }

        [Test, Order(2)]
        public void Put()
        {
            // Arange
            this.data = GetAllDataInDatabase();
            this.test.SampleUpdate.Id = data.First().Id;
            // Act
            this.apiCaller.Put(this.commercialistControllerUrls.Url, this.test.SampleUpdate);
            data = this.GetAllDataInDatabase();
            // Assert
            Assert.AreEqual(this.test.SampleUpdate.FirstName, data.First().FirstName);
        }

        [Test, Order(3)]
        public void Delete()
        {
            // Arrange
            this.test.SampleDelete.Id = GetAllDataInDatabase().First().Id;
            // Act
            this.apiCaller.Delete(this.commercialistControllerUrls.Url, this.test.SampleDelete);
            data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsEmpty(data.ToList());
        }
    }
}