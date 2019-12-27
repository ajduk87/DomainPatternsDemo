using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.SalesChannel;
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
    public class SalesChannelControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private SalesChannelControllerUrls salesChannelControllerUrls;
        private SalesChannelData test;
        private IEnumerable<SalesChannelDto> data;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.salesChannelControllerUrls = new SalesChannelControllerUrls();
            this.test = new SalesChannelData();
        }

        private IEnumerable<SalesChannelDto> GetAllDataFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<SalesChannelDto>(GetAllData.SalesChannel);
            }
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.SalesChannel);
            }
            // Act
            this.apiCaller.Post(this.salesChannelControllerUrls.Url, this.test.SampleCreate);
            this.data = GetAllDataFromDatabase();
            // Assert
            Assert.IsNotEmpty(this.data.ToList());
        }

        [Test, Order(2)]
        public void Put()
        {
            // Arrange
            this.test.SampleUpdate.Id = this.data.First().Id;
            // Act
            this.apiCaller.Put(this.salesChannelControllerUrls.Url, this.test.SampleUpdate);
            this.data = GetAllDataFromDatabase();
            //
            Assert.AreEqual(this.test.SampleUpdate.Name, this.data.First().Name);
            Assert.AreEqual(this.test.SampleUpdate.Description, this.data.First().Description);
        }

        [Test, Order(3)]
        public void Delete()
        {
            // Arrange
            this.test.SampleDelete.Id = this.data.First().Id;
            // Act
            this.apiCaller.Delete(this.salesChannelControllerUrls.Url, this.test.SampleDelete);
            this.data = GetAllDataFromDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
        }
    }
}
