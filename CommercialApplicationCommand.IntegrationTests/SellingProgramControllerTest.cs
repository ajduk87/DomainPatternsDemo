using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.SellingProgram;
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
    public class SellingProgramControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private SellingProgramControllerUrls sellingProgramUrls;
        private IEnumerable<SellingProgramDto> data;
        private SellingProgramData test;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.sellingProgramUrls = new SellingProgramControllerUrls();
            this.test = new SellingProgramData();
        }

        private IEnumerable<SellingProgramDto> GetAllDataInDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<SellingProgramDto>(GetAllData.SellingProgram);
            }
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.InvoiceCommercialist);
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.InvoiceItemInvoice);
                connection.Execute(Clean.InvoiceItem);
                connection.Execute(Clean.Invoice);
                connection.Execute(Clean.SellingProgram);
            }
            // Act
            this.apiCaller.Post(this.sellingProgramUrls.Url, this.test.SampleCreate);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsNotEmpty(this.data.ToList());
        }

        [Test, Order(2)]
        public void Put()
        {
            // Arrange
            this.test.SampleUpdate.Id = this.data.First().Id;
            // Act
            this.apiCaller.Put(this.sellingProgramUrls.Url, this.test.SampleUpdate);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.AreEqual(this.test.SampleUpdate.SellingProgram, this.data.First().SellingProgram);
            Assert.AreEqual(this.test.SampleUpdate.SellingCondition, this.data.First().SellingCondition);
            Assert.AreEqual(this.test.SampleUpdate.DayForPaying, this.data.First().DayForPaying);
        }

        [Test, Order(3)]
        public void Delete()
        {
            // Arrange
            this.test.SampleDelete.Id = this.data.First().Id;
            // Act
            this.apiCaller.Delete(this.sellingProgramUrls.Url, this.test.SampleDelete);
            this.data = this.GetAllDataInDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
        }
    }
}
