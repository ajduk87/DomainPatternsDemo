using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Commercialist;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Contact;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Location;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Order;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.SalesChannel;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.SellingProgram;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
using CommercialApplicationCommand.ApplicationLayer.Models.Action;
using CommercialApplicationCommand.ApplicationLayer.Models.Commercialist;
using CommercialApplicationCommand.ApplicationLayer.Models.CommercialistLocation;
using CommercialApplicationCommand.ApplicationLayer.Models.Contact;
using CommercialApplicationCommand.ApplicationLayer.Models.Customer;
using CommercialApplicationCommand.ApplicationLayer.Models.CustomerContact;
using CommercialApplicationCommand.ApplicationLayer.Models.CustomerLocation;
using CommercialApplicationCommand.ApplicationLayer.Models.CustomerSalesChannel;
using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItem;
using CommercialApplicationCommand.ApplicationLayer.Models.Invoices;
using CommercialApplicationCommand.ApplicationLayer.Models.Location;
using CommercialApplicationCommand.ApplicationLayer.Models.Order;
using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.ProductStorage;
using CommercialApplicationCommand.ApplicationLayer.Models.SalesChannel;
using CommercialApplicationCommand.ApplicationLayer.Models.SellingProgram;
using CommercialApplicationCommand.ApplicationLayer.Models.Storage;
using CommercialApplicationCommand.ApplicationLayer.Registration.Containers;
using CommercialApplicationCommand.IntegrationTests.Setup;
using CommercialApplicationCommand.IntegrationTests.TestsData;
using CommercialApplicationCommand.IntegrationTests.Urls;
using Dapper;
using Npgsql;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests
{
    public class DataImportTest : TestBase
    {
        private RegistrationAppServices registrationAppServices;
        private IDatabaseConnectionFactory databaseConnectionFactory;
        private DatabaseParameters databaseParameters;
        private ActionControllerUrls actionControllerUrls;
        private ContactControllerUrls contactControllerUrls;
        private CommercialistControllerUrls commercialistControllerUrls;
        private CommercialistLocationControllerUrls commercialistLocationControllerUrls;
        private CustomerControllerUrls customerControllerUrls;
        private CustomerLocationControllerUrls customerLocationControllerUrls;
        private CustomerSalesChannelControllerUrls customerSalesChannelControllerUrls;
        private CustomerContactControllerUrls customerContactControllerUrls;
        private LocationControllerUrls locationControllerUrls;
        private ProductControllerUrls productControllerUrls;
        private StorageControllerUrls storageControllerUrls;
        private ProductStorageControllerUrls productStorageControllerUrls;
        private SellingProgramControllerUrls sellingProgramControllerUrls;
        private SalesChannelControllerUrls salesChannelControllerUrls;
        private InvoiceControllerUrls invoiceControllerUrls;
        private OrderControllerUrls orderControllerUrls;
        private IEnumerable<SalesChannelDto> salesChannelData;
        private IEnumerable<ActionDto> actionData;
        private IEnumerable<ProductDtoTest> productData;
        private IEnumerable<StorageDto> storageData;
        private IEnumerable<ContactDto> contactData;
        private IEnumerable<LocationDto> locationData;
        private IEnumerable<CustomerDto> customerData;
        private IEnumerable<SellingProgramDto> sellingProgramData;
        private IEnumerable<CommercialistDto> commercialistData;
        private IEnumerable<InvoiceDto> invoiceData;
        private IEnumerable<OrderDto> orderData;
        private Random numberGenerator;
        private SampleData testData;

        [SetUp]
        public void SetUp()
        {
            this.registrationAppServices = new RegistrationAppServices();
            this.databaseConnectionFactory = this.registrationAppServices.Instance.Container.Resolve<IDatabaseConnectionFactory>();
            this.databaseParameters = new DatabaseParameters();
            this.actionControllerUrls = new ActionControllerUrls();
            this.locationControllerUrls = new LocationControllerUrls();
            this.commercialistControllerUrls = new CommercialistControllerUrls();
            this.commercialistLocationControllerUrls = new CommercialistLocationControllerUrls();
            this.customerControllerUrls = new CustomerControllerUrls();
            this.customerLocationControllerUrls = new CustomerLocationControllerUrls();
            this.customerContactControllerUrls = new CustomerContactControllerUrls();
            this.customerSalesChannelControllerUrls = new CustomerSalesChannelControllerUrls();
            this.contactControllerUrls = new ContactControllerUrls();
            this.productControllerUrls = new ProductControllerUrls();
            this.storageControllerUrls = new StorageControllerUrls();
            this.salesChannelControllerUrls = new SalesChannelControllerUrls();
            this.productStorageControllerUrls = new ProductStorageControllerUrls();
            this.sellingProgramControllerUrls = new SellingProgramControllerUrls();
            this.invoiceControllerUrls = new InvoiceControllerUrls();
            this.orderControllerUrls = new OrderControllerUrls();
            this.numberGenerator = new Random();
            this.testData = new SampleData();
        }

        IEnumerable<ProductDtoTest> GetAllProductsFromDatabase(IDbConnection connection)
        {
            return connection.Query<ProductDtoTest>(GetAllData.Product);
        }

        IEnumerable<StorageDto> GetAllStoragesFromDatabase(IDbConnection connection)
        {
            return connection.Query<StorageDto>(GetAllData.Storage);
        }

        IEnumerable<CustomerDto> GetAllCustomersFromDatabase(IDbConnection connection)
        {
            return connection.Query<CustomerDto>(GetAllData.Customer);
        }

        IEnumerable<CommercialistDto> GetAllCommercialistsFromDatabase(IDbConnection connection)
        {
            return connection.Query<CommercialistDto>(GetAllData.Commercialist);
        }

        IEnumerable<ContactDto> GetAllContactsFromDatabase(IDbConnection connection)
        {
            return connection.Query<ContactDto>(GetAllData.Contact);
        }

        IEnumerable<LocationDto> GetAllLocationsFromDatabase(IDbConnection connection)
        {
            return connection.Query<LocationDto>(GetAllData.Location);
        }

        IEnumerable<ActionDto> GetAllActionsFromDatabase(IDbConnection connection)
        {
            return connection.Query<ActionDto>(GetAllData.Action);
        }

        IEnumerable<SellingProgramDto> GetAllSellingProgramsFromDatabase(IDbConnection connection)
        {
            return connection.Query<SellingProgramDto>(GetAllData.SellingProgram);
        }

        IEnumerable<InvoiceDto> GetAllInvoicesFromDatabase(IDbConnection connection)
        {
            return connection.Query<InvoiceDto>(GetAllData.Invoice);
        }

        IEnumerable<OrderDto> GetAllOrdersFromDatabase(IDbConnection connection)
        {
            return connection.Query<OrderDto>(GetAllData.Order);
        }

        IEnumerable<SalesChannelDto> GetAllSalesChannelsFromDatabase(IDbConnection connection)
        {
            return connection.Query<SalesChannelDto>(GetAllData.SalesChannel);
        }

        [Test]
        public void InsertData()
        {
            // Arrange
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create(this.databaseParameters.ConnectionString))
            {
                connection.Execute(Clean.OrderItemOrder);
                connection.Execute(Clean.OrderCommercialist);
                connection.Execute(Clean.OrderCustomer);
                connection.Execute(Clean.OrderItem);
                connection.Execute(Clean.Order);
                connection.Execute(Clean.InvoiceCustomer);
                connection.Execute(Clean.InvoiceCommercialist);
                connection.Execute(Clean.InvoiceItemInvoice);
                connection.Execute(Clean.InvoiceItem);
                connection.Execute(Clean.Invoice);
                connection.Execute(Clean.Action);
                connection.Execute(Clean.ProductStorage);
                connection.Execute(Clean.Storage);
                connection.Execute(Clean.Product);
                connection.Execute(Clean.CustomerLocation);
                connection.Execute(Clean.CustomerContact);
                connection.Execute(Clean.CustomerSalesChannel);
                connection.Execute(Clean.Customer);
                connection.Execute(Clean.SalesChannel);
                connection.Execute(Clean.Contact);
                connection.Execute(Clean.CommercialistLocation);
                connection.Execute(Clean.Commercialist);
                connection.Execute(Clean.Location);
                connection.Execute(Clean.SellingProgram);

                // Insert products

                foreach (ProductCreateModel product in this.testData.Products)
                {
                    this.apiCaller.Post(this.productControllerUrls.Url, product);
                }

                this.productData = GetAllProductsFromDatabase(connection);

                // Insert storages

                foreach (StorageCreateModel storage in this.testData.Storages)
                {
                    this.apiCaller.Post(this.storageControllerUrls.Url, storage);
                }

                this.storageData = GetAllStoragesFromDatabase(connection);

                foreach (StorageDto storage in this.storageData)
                {
                    foreach (ProductDtoTest product in this.productData)
                    {
                        ProductStorageCreateModel productStorage = new ProductStorageCreateModel
                        {
                            ProductId = product.Id,
                            StorageId = storage.Id,
                            AmountOfProduct = this.numberGenerator.Next(100, 200)
                        };

                        this.apiCaller.Post(this.productStorageControllerUrls.Url, productStorage);
                    }
                }

                // Insert customers

                foreach (CustomerCreateModel customer in this.testData.Customers)
                {
                    this.apiCaller.Post(this.customerControllerUrls.Url, customer);
                }

                this.customerData = GetAllCustomersFromDatabase(connection);
                List<CustomerDto> customers = this.customerData.ToList();

                // Insert Sales channels

                foreach(SalesChannelCreateModel salesChannel in this.testData.SalesChannels)
                {
                    this.apiCaller.Post(this.salesChannelControllerUrls.Url, salesChannel);
                }

                this.salesChannelData = this.GetAllSalesChannelsFromDatabase(connection);
                List<SalesChannelDto> salesChannels = this.salesChannelData.ToList();

                // Insert CustomerSalesChannel

                foreach(CustomerDto customer in this.customerData)
                {
                    CustomerSalesChannelCreateModel customerSalesChannel = new CustomerSalesChannelCreateModel
                    {
                        CustomerId = customer.Id,
                        SalesChannelId = salesChannels[this.numberGenerator.Next(salesChannels.Count-1)].Id
                    };

                    this.apiCaller.Post(this.customerSalesChannelControllerUrls.Url, customerSalesChannel);
                }

                // Insert actions

                foreach (ProductDtoTest product in this.productData)
                {
                    CustomerDto randomCustomer = customers[this.numberGenerator.Next(customers.Count - 1)];
                    ActionCreateModel action = new ActionCreateModel
                    {
                        Discount = numberGenerator.NextDouble(),
                        ProductId = product.Id,
                        CustomerId = randomCustomer.Id,
                        ThresholdAmount = this.numberGenerator.Next(5, 60)
                    };

                    this.apiCaller.Post(this.actionControllerUrls.Url, action);
                    customers.Remove(randomCustomer);
                }

                this.actionData = GetAllActionsFromDatabase(connection);

                // Insert locations

                foreach (LocationCreateModel location in this.testData.Locations)
                {
                    this.apiCaller.Post(this.locationControllerUrls.Url, location);
                }

                this.locationData = this.GetAllLocationsFromDatabase(connection);
                List<LocationDto> locations = this.locationData.ToList();

                // Insert contacts and customerContact

                customers = this.GetAllCustomersFromDatabase(connection).ToList();

                foreach (ContactCreateModel contact in this.testData.Contacts)
                {
                    CustomerDto randomCustomer = customers[this.numberGenerator.Next(customers.Count - 1)];
                    contact.CustomerId = randomCustomer.Id;
                    this.apiCaller.Post(this.contactControllerUrls.Url, contact);

                    CustomerContactCreateModel customerContact = new CustomerContactCreateModel
                    {
                        CustomerId = contact.CustomerId,
                        ContactId = this.GetAllContactsFromDatabase(connection).Where(c => c.Email == contact.Email && c.Phone == contact.Phone).First().Id
                    };

                    this.apiCaller.Post(this.customerContactControllerUrls.Url, customerContact);
                    customers.Remove(randomCustomer);
                }

                this.contactData = GetAllContactsFromDatabase(connection);

                // Insert customerLocation

                foreach (CustomerDto customer in this.customerData)
                {
                    LocationDto randomLocation = locations[this.numberGenerator.Next(locations.Count - 1)];

                    CustomerLocationCreateModel customerLocation = new CustomerLocationCreateModel
                    {
                        CustomerId = customer.Id,
                        LocationId = randomLocation.Id
                    };

                    this.apiCaller.Post(this.customerLocationControllerUrls.Url, customerLocation);

                    locations.Remove(randomLocation);
                }

                // Insert commercialist

                foreach (CommercialistCreateModel commercialist in this.testData.Commercialists)
                {
                    this.apiCaller.Post(this.commercialistControllerUrls.Url, commercialist);
                }

                this.commercialistData = this.GetAllCommercialistsFromDatabase(connection);
                List<CommercialistDto> commercialists = this.commercialistData.ToList();
                locations = this.locationData.ToList();

                // Insert commercialistLocation

                foreach (CommercialistDto commercialist in commercialistData)
                {
                    LocationDto randomLocation = locations[numberGenerator.Next(locations.Count - 1)];
                    CommercialistLocationCreateModel commercialistLocation = new CommercialistLocationCreateModel
                    {
                        CommercialistId = commercialist.Id,
                        LocationId = randomLocation.Id
                    };
                    this.apiCaller.Post(this.commercialistLocationControllerUrls.Url, commercialistLocation);
                    locations.Remove(randomLocation);
                }

                // Insert selling programs

                foreach (SellingProgramCreateModel sellingProgram in this.testData.SellingPrograms)
                {
                    this.apiCaller.Post(this.sellingProgramControllerUrls.Url, sellingProgram);
                }

                this.sellingProgramData = this.GetAllSellingProgramsFromDatabase(connection);

                // Insert orders

                commercialists = this.commercialistData.ToList();
                customers = this.customerData.ToList();

                foreach (OrderCreateModel order in this.testData.Orders)
                {
                    CommercialistDto randomCommercialist = commercialists[this.numberGenerator.Next(commercialists.Count - 1)];
                    CustomerDto randomCustomer = customers[this.numberGenerator.Next(customers.Count - 1)];
                    order.CommercialistId = randomCommercialist.Id;
                    order.CustomerId = randomCustomer.Id;
                    List<ProductDtoTest> products = this.productData.ToList();
                    List<ActionDto> actions = this.actionData.ToList();
                    foreach (OrderItemCreateModel orderItem in order.orderItems)
                    {
                        ProductDtoTest randomProduct = products[this.numberGenerator.Next(products.Count - 1)];
                        ActionDto randomAction = actions[this.numberGenerator.Next(actions.Count - 1)];
                        orderItem.ProductId = randomProduct.Id;
                        orderItem.ActionId = randomAction.Id;
                        products.Remove(randomProduct);
                        actions.Remove(randomAction);
                    }

                    commercialists.Remove(randomCommercialist);
                    customers.Remove(randomCustomer);
                    this.apiCaller.Post(this.orderControllerUrls.Url, order);
                }

                // Insert invoices

                commercialists = this.commercialistData.ToList();
                customers = this.customerData.ToList();
                List<SellingProgramDto> sellingPrograms = this.sellingProgramData.ToList();

                foreach (InvoiceCreateModel invoice in this.testData.Invoices)
                {
                    CommercialistDto randomCommercialist = commercialists[this.numberGenerator.Next(commercialists.Count - 1)];
                    CustomerDto randomCustomer = customers[this.numberGenerator.Next(customers.Count - 1)];
                    SellingProgramDto randomSellingProgram = sellingPrograms[this.numberGenerator.Next(sellingPrograms.Count - 1)];
                    invoice.CommercialistId = randomCommercialist.Id;
                    invoice.CustomerId = randomCustomer.Id;
                    invoice.SellingProgramId = randomSellingProgram.Id;
                    List<ProductDtoTest> products = this.productData.ToList();
                    List<ActionDto> actions = this.actionData.ToList();
                    foreach (InvoiceItemCreateModel invoiceItem in invoice.InvoiceItems)
                    {
                        ActionDto randomAction = actions[this.numberGenerator.Next(actions.Count - 1)];
                        ProductDtoTest randomProduct = products[this.numberGenerator.Next(products.Count - 1)];
                        invoiceItem.ActionId = randomAction.Id;
                        invoiceItem.ProductId = randomProduct.Id;

                        actions.Remove(randomAction);
                        products.Remove(randomProduct);
                    }

                    this.apiCaller.Post(this.invoiceControllerUrls.Url, invoice);

                    commercialists.Remove(randomCommercialist);
                    customers.Remove(randomCustomer);
                    sellingPrograms.Remove(randomSellingProgram);
                }

                // Act

                this.actionData = this.GetAllActionsFromDatabase(connection);
                this.productData = this.GetAllProductsFromDatabase(connection);
                this.storageData = this.GetAllStoragesFromDatabase(connection);
                this.salesChannelData = this.GetAllSalesChannelsFromDatabase(connection);
                this.locationData = this.GetAllLocationsFromDatabase(connection);
                this.commercialistData = this.GetAllCommercialistsFromDatabase(connection);
                this.customerData = this.GetAllCustomersFromDatabase(connection);
                this.contactData = this.GetAllContactsFromDatabase(connection);
                this.sellingProgramData = this.GetAllSellingProgramsFromDatabase(connection);
                this.invoiceData = this.GetAllInvoicesFromDatabase(connection);
                this.orderData = this.GetAllOrdersFromDatabase(connection);

                // Assert

                Assert.IsNotEmpty(this.actionData.ToList());
                Assert.IsNotEmpty(this.salesChannelData.ToList());
                Assert.IsNotEmpty(this.productData.ToList());
                Assert.IsNotEmpty(this.storageData.ToList());
                Assert.IsNotEmpty(this.locationData.ToList());
                Assert.IsNotEmpty(this.commercialistData.ToList());
                Assert.IsNotEmpty(this.customerData.ToList());
                Assert.IsNotEmpty(this.contactData.ToList());
                Assert.IsNotEmpty(this.sellingProgramData.ToList());
                Assert.IsNotEmpty(this.invoiceData.ToList());
                Assert.IsNotEmpty(this.orderData.ToList());
            }
        }
    }

}
