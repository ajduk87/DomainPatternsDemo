using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
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
    public class StorageControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private StorageControllerUrls storageControllerUrls;
        private DatabaseParameters databaseParameters;
        private IEnumerable<StorageDto> data;
        private StorageData test;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.storageControllerUrls = new StorageControllerUrls();
            this.databaseParameters = new DatabaseParameters();

            this.test = new StorageData();
        }

        private IEnumerable<StorageDto> GetAllDataInDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<StorageDto>(GetAllData.Storage);
            }
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.ProductStorage);
                connection.Execute(Clean.Storage);
                connection.Execute(Clean.Product);
            }
            // Act
            this.apiCaller.Post(this.storageControllerUrls.Url, this.test.SampleCreate);
            this.data = GetAllDataInDatabase();
            // Assert
            Assert.IsNotEmpty(this.data.ToList());
        }
        [Test, Order(2)]
        public void Put()
        {
            // Arrange
            this.test.SampleUpdate.Id = this.data.First().Id;
            // Act
            this.apiCaller.Put(this.storageControllerUrls.Url, this.test.SampleUpdate);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.AreEqual(this.data.First().Name, this.test.SampleUpdate.Name);
            Assert.AreEqual(this.data.First().Location, this.test.SampleUpdate.Location);
        }

        [Test, Order(3)]
        public void Delete()
        {
            // Arrange
            this.test.SampleDelete.Id = this.data.First().Id;
            // Act
            this.apiCaller.Delete(this.storageControllerUrls.Url, this.test.SampleDelete);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
        }
    }
}
