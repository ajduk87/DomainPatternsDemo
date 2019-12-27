using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Commercialist;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.SellingProgram;
using CommercialApplicationCommand.ApplicationLayer.Models.Action;
using CommercialApplicationCommand.ApplicationLayer.Models.Product;
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
    public class InvoiceControllerTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private InvoiceControllerUrls invoiceControllerUrls;
        private CustomerControllerUrls customerControllerUrls;
        private CommercialistControllerUrls commercialistControllerUrls;
        private SellingProgramControllerUrls sellingProgramUrls;
        private ProductControllerUrls productControllerUrls;
        private ActionControllerUrls actionControllerUrls;
        private InvoiceData testInvoice;
        private ProductDataForOrderAndInvoiceTesting productDataForOrderAndInvoiceTesting;
        private CustomerData testCustomer;
        private CommercialistData testCommercialist;
        private SellingProgramData testSellingProgram;
        private Random numberGenerator;
        private IEnumerable<InvoiceDto> data;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.invoiceControllerUrls = new InvoiceControllerUrls();
            this.productControllerUrls = new ProductControllerUrls();
            this.sellingProgramUrls = new SellingProgramControllerUrls();
            this.commercialistControllerUrls = new CommercialistControllerUrls();
            this.customerControllerUrls = new CustomerControllerUrls();
            this.productControllerUrls = new ProductControllerUrls();
            this.actionControllerUrls = new ActionControllerUrls();
            this.testInvoice = new InvoiceData();
            this.productDataForOrderAndInvoiceTesting = new ProductDataForOrderAndInvoiceTesting();
            this.testCustomer = new CustomerData();
            this.testCommercialist = new CommercialistData();
            this.testSellingProgram = new SellingProgramData();
            this.numberGenerator = new Random();

        }

        private IEnumerable<ProductDtoTest> GetAllProductsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ProductDtoTest>(GetAllData.Product);
            }
        }

        private IEnumerable<ActionDto> GetAllActionsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<ActionDto>(GetAllData.Action);
            }
        }

        private IEnumerable<CommercialistDto> GetAllCommercialistsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CommercialistDto>(GetAllData.Commercialist);
            }
        }

        private IEnumerable<SellingProgramDto> GetAllSellingProgramsFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<SellingProgramDto>(GetAllData.SellingProgram);
            }
        }

        private IEnumerable<CustomerDto> GetAllCustomersFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<CustomerDto>(GetAllData.Customer);
            }
        }

        private IEnumerable<InvoiceDto> GetAllInvoicesFromDatabase()
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                return connection.Query<InvoiceDto>(GetAllData.Invoice);
            }
        }

        [Test, Order(1)]
        public void Post()
        {
            // Arrange
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.InvoiceItemInvoice);
                connection.Execute(Clean.InvoiceItem);
                connection.Execute(Clean.InvoiceCommercialist);
                connection.Execute(Clean.Invoice);
                connection.Execute(Clean.CommercialistLocation);
                connection.Execute(Clean.OrderCommercialist);
                connection.Execute(Clean.OrderItemOrder);
                connection.Execute(Clean.OrderItem);
                connection.Execute(Clean.Commercialist);
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.CustomerContact);
                connection.Execute(Clean.CustomerLocation);
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.OrderCustomer);
                connection.Execute(Clean.SellingProgram);
                connection.Execute(Clean.Action);
                connection.Execute(Clean.Customer);
                connection.Execute(Clean.ProductStorage);
                connection.Execute(Clean.Product);
            }
            this.apiCaller.Post(this.customerControllerUrls.Url, this.testCustomer.SampleCreate);
            long customerId = this.GetAllCustomersFromDatabase().First().Id;
            using (var products = this.productDataForOrderAndInvoiceTesting.Products.GetEnumerator())
            using (var invoiceItems = this.testInvoice.SampleCreate.InvoiceItems.GetEnumerator())
            {
                while(products.MoveNext() && invoiceItems.MoveNext())
                {
                    this.apiCaller.Post(this.productControllerUrls.Url, products.Current);
                    long productId = this.GetAllProductsFromDatabase().Where(p => p.Name == products.Current.Name).First().Id;
                    ActionCreateModel actionCreateModel = new ActionCreateModel
                    {
                        ThresholdAmount = this.numberGenerator.Next(10, 90),
                        CustomerId = customerId,
                        Discount = this.numberGenerator.NextDouble(),
                        ProductId = productId
                    };
                    this.apiCaller.Post(this.actionControllerUrls.Url, actionCreateModel);
                    long actionId = this.GetAllActionsFromDatabase().Where(a => a.ProductId == productId).First().Id;
                    invoiceItems.Current.ProductId = productId;
                    invoiceItems.Current.ActionId = actionId;
                }
            }
            
            this.apiCaller.Post(this.commercialistControllerUrls.Url, this.testCommercialist.SampleCreate);
            this.apiCaller.Post(this.sellingProgramUrls.Url, this.testSellingProgram.SampleCreate);
            this.testInvoice.SampleCreate.CommercialistId = this.GetAllCommercialistsFromDatabase().First().Id;
            this.testInvoice.SampleCreate.CustomerId = customerId;
            this.testInvoice.SampleCreate.SellingProgramId = this.GetAllSellingProgramsFromDatabase().First().Id;
            // Act
            this.apiCaller.Post(this.invoiceControllerUrls.Url, this.testInvoice.SampleCreate);
            this.data = GetAllInvoicesFromDatabase();
            // Assert
            Assert.IsNotEmpty(this.data.ToList());
        }

        [Test, Order(2)]
        public void Delete()
        {
            // Arrange
            this.testInvoice.SampleDelete.Id = this.data.First().Id;
            // Act
            this.apiCaller.Delete(this.invoiceControllerUrls.Url, this.testInvoice.SampleDelete);
            this.data = GetAllInvoicesFromDatabase();
            // Assert
            Assert.IsEmpty(this.data.ToList());
            using( NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.Commercialist);
                connection.Execute(Clean.Action);
                connection.Execute(Clean.Customer);
                connection.Execute(Clean.SellingProgram);
                connection.Execute(Clean.Product);
            }
        }
    }
}
