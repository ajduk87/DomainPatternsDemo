using Autofac;
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
    public class LocationControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private LocationControllerUrls locationControllerUrls;
        private LocationData test;
        private IEnumerable<LocationDto> data;

        [SetUp]
        public void Setup()
        {
            this.locationControllerUrls = new LocationControllerUrls();
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseParameters = new DatabaseParameters();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();

            this.test = new LocationData();
        }

        private IEnumerable<LocationDto> GetAllDataInDatabase()
        {
            using(NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<LocationDto>(GetAllData.Location);
            }
        }
        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using(NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.CustomerLocation);
                connection.Execute(Clean.CommercialistLocation);
                connection.Execute(Clean.Location);
            }
            // Act
            this.apiCaller.Post(this.locationControllerUrls.Url, this.test.SampleCreate);
            data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsNotEmpty(data.ToList());
        }

        [Test, Order(2)]
        public void Update()
        {
            // Arrange
            this.data = GetAllDataInDatabase();
            this.test.SampleUpdate.Id = this.data.First().Id;
            // Act
            this.apiCaller.Put(this.locationControllerUrls.Url, this.test.SampleUpdate);
            data = this.GetAllDataInDatabase();
            // Assert
            Assert.AreEqual(this.test.SampleUpdate.MarketplaceName, this.data.First().MarketplaceName);
        }

        [Test, Order(3)]
        public void Delete()
        {
            // Arrange
            this.test.SampleDelete.Id = this.GetAllDataInDatabase().First().Id;
            // Act
            this.apiCaller.Delete(this.locationControllerUrls.Url, this.test.SampleDelete);
            data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsEmpty(data.ToList());
        }
    }
}
