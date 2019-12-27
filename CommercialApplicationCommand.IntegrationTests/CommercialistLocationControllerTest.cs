using Autofac;
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
    class CommercialistLocationControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private CommercialistLocationControllerUrls commercialistLocationControllerUrls;
        private CommercialistControllerUrls commercialistControllerUrls;
        private LocationControllerUrls locationControllerUrls;
        private DatabaseParameters databaseParameters;
        private CommercialistLocationData testCommercialistLocation;
        private CommercialistData testCommercialist;
        private LocationData testLocation;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.commercialistLocationControllerUrls = new CommercialistLocationControllerUrls();
            this.commercialistControllerUrls = new CommercialistControllerUrls();
            this.locationControllerUrls = new LocationControllerUrls();
            this.testCommercialistLocation = new CommercialistLocationData();
            this.testLocation = new LocationData();
            this.testCommercialist = new CommercialistData();
        }

        private IEnumerable<CommercialistLocationDto> GetAllCommercialistLocationsInDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CommercialistLocationDto>(GetAllData.CommercialistLocation);
            }
        }

        private IEnumerable<CommercialistDto> GetAllCommercialistsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CommercialistDto>(GetAllData.Commercialist);
            }
        }

        private IEnumerable<LocationDto> GetAllLocationsFromDatabase()
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
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.InvoiceCommercialist);
                connection.Execute(Clean.OrderCommercialist);
                connection.Execute(Clean.CommercialistLocation);
                connection.Execute(Clean.Commercialist);
                connection.Execute(Clean.Location);
            }
            // Act
            this.apiCaller.Post(this.locationControllerUrls.Url, this.testLocation.SampleCreate);
            this.apiCaller.Post(this.commercialistControllerUrls.Url, this.testCommercialist.SampleCreate);
            this.testCommercialistLocation.SampleCreate.CommercialistId = this.GetAllCommercialistsFromDatabase().First().Id;
            this.testCommercialistLocation.SampleCreate.LocationId = this.GetAllLocationsFromDatabase().First().Id;
            this.apiCaller.Post(this.commercialistLocationControllerUrls.Url, this.testCommercialistLocation.SampleCreate);
            this.data = this.GetAllCommercialistLocationsInDatabase();
            // Assert
            Assert.IsNotEmpty(this.data.ToList());
        }

        [Test, Order(2)]
        public void Delete()
        {
            // Arrange
            this.testCommercialist.SampleDelete.Id = this.GetAllCommercialistsFromDatabase().First().Id;
            this.testLocation.SampleDelete.Id = this.GetAllLocationsFromDatabase().First().Id;
            this.testCommercialistLocation.SampleDelete.CommercialistId = this.testCommercialist.SampleDelete.Id;
            this.testCommercialistLocation.SampleDelete.LocationId = this.testLocation.SampleDelete.Id;
            // Act
            this.apiCaller.Delete(this.commercialistLocationControllerUrls.Url, this.testCommercialistLocation.SampleDelete);
            this.apiCaller.Delete(this.commercialistControllerUrls.Url, this.testCommercialist.SampleDelete);
            this.apiCaller.Delete(this.locationControllerUrls.Url, this.testLocation.SampleDelete);
            this.data = this.GetAllCommercialistLocationsInDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
        }
    }
}
