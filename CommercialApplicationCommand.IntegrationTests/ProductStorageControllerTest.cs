using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
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
    class ProductStorageControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private ProductStorageControllerUrls productStorageControllerUrls;
        private ProductControllerUrls productControllerUrls;
        private StorageControllerUrls storageControllerUrls;
        private DatabaseParameters databaseParameters;
        private IEnumerable<ProductStorageDto> data;
        private ProductStorageData testProductStorage;
        private ProductEntityTest testProduct;
        private StorageData testStorage;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.productStorageControllerUrls = new ProductStorageControllerUrls();
            this.productControllerUrls = new ProductControllerUrls();
            this.storageControllerUrls = new StorageControllerUrls();
            this.testProductStorage = new ProductStorageData();
            this.testProduct = new ProductEntityTest();
            this.testStorage = new StorageData();
        }

        private IEnumerable<ProductDtoTest> GetAllProductsFromDatabase()
        {
            using (NpgsqlConnection connection  = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ProductDtoTest>(GetAllData.Product);
            }
        }

        private IEnumerable<StorageDto> GetAllStoragesFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<StorageDto>(GetAllData.Storage);
            }
        }

        private IEnumerable<ProductStorageDto> GetAllProductStoragesFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ProductStorageDto>(GetAllData.ProductStorage);
            }
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using(NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.ProductStorage);
                connection.Execute(Clean.Storage);
                connection.Execute(Clean.Product);
            }
            // Act
            this.apiCaller.Post(this.productControllerUrls.Url, this.testProduct.SampleCreate);
            this.apiCaller.Post(this.storageControllerUrls.Url, this.testStorage.SampleCreate);
            this.testProductStorage.SampleCreate.ProductId = this.GetAllProductsFromDatabase().First().Id;
            this.testProductStorage.SampleCreate.StorageId = this.GetAllStoragesFromDatabase().First().Id;
            this.apiCaller.Post(this.productStorageControllerUrls.Url, this.testProductStorage.SampleCreate);
            this.data = this.GetAllProductStoragesFromDatabase();
            // Assert
            Assert.IsNotEmpty(this.data.ToList());
        }

        [Test, Order(2)]
        public void Delete()
        {
            // Arrange
            this.testStorage.SampleDelete.Id = GetAllStoragesFromDatabase().First().Id;
            this.testProduct.SampleDelete.Id = GetAllProductsFromDatabase().First().Id;
            this.testProductStorage.SampleDelete.ProductId = this.testProduct.SampleDelete.Id;
            this.testProductStorage.SampleDelete.StorageId = this.testStorage.SampleDelete.Id;
            // Act
            this.apiCaller.Delete(this.productStorageControllerUrls.Url, this.testProductStorage.SampleDelete);
            this.apiCaller.Delete(this.storageControllerUrls.Url, this.testStorage.SampleDelete);
            this.apiCaller.Delete(this.productControllerUrls.Url, this.testProduct.SampleDelete);
            this.data = GetAllProductStoragesFromDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
        }
    }
}
