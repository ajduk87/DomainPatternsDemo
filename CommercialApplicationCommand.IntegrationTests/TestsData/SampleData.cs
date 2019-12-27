using CommercialApplicationCommand.ApplicationLayer.Models.Commercialist;
using CommercialApplicationCommand.ApplicationLayer.Models.Contact;
using CommercialApplicationCommand.ApplicationLayer.Models.Customer;
using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItem;
using CommercialApplicationCommand.ApplicationLayer.Models.Invoices;
using CommercialApplicationCommand.ApplicationLayer.Models.Location;
using CommercialApplicationCommand.ApplicationLayer.Models.Order;
using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using CommercialApplicationCommand.ApplicationLayer.Models.SalesChannel;
using CommercialApplicationCommand.ApplicationLayer.Models.SellingProgram;
using CommercialApplicationCommand.ApplicationLayer.Models.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class SampleData
    {
        public IEnumerable<ProductCreateModel> Products;
        public IEnumerable<CommercialistCreateModel> Commercialists;
        public IEnumerable<CustomerCreateModel> Customers;
        public IEnumerable<LocationCreateModel> Locations;
        public IEnumerable<StorageCreateModel> Storages;
        public IEnumerable<SalesChannelCreateModel> SalesChannels;
        public IEnumerable<ContactCreateModel> Contacts;
        public IEnumerable<SellingProgramCreateModel> SellingPrograms;
        public IEnumerable<InvoiceCreateModel> Invoices;
        public IEnumerable<OrderCreateModel> Orders;

        public SampleData()
        {
            this.Products = new ProductDataForOrderAndInvoiceTesting().Products;

            this.Commercialists = new CommercialistCreateModel[]
            {
                new CommercialistCreateModel
                {
                    FirstName = "Pera",
                    LastName = "Peric",
                    Password = "pera",
                    Username = "zdera"
                },
                new CommercialistCreateModel
                {
                    FirstName = "Ime",
                    LastName = "Prezime",
                    Password = "sifra123",
                    Username = "JohnDoe"
                },
                new CommercialistCreateModel
                {
                    FirstName = "Name",
                    LastName = "Surname",
                    Password = "p@$$word",
                    Username = "Komercijala"
                },
                new CommercialistCreateModel
                {
                    FirstName = "Badza",
                    LastName = "Badzic",
                    Password = "sifra54321",
                    Username = "badza"
                },
                new CommercialistCreateModel
                {
                    FirstName = "Mornar",
                    LastName = "Popaj",
                    Password = "s1fr@1234",
                    Username = "Popeye"
                }
            };

            this.Customers = new CustomerCreateModel[]
            {
                new CustomerCreateModel
                {
                    Name = "Milos"
                },
                new CustomerCreateModel
                {
                    Name = "Nikola"
                },
                new CustomerCreateModel
                {
                    Name = "Bojan"
                },
                new CustomerCreateModel
                {
                    Name = "Nenad"
                },
                new CustomerCreateModel
                {
                    Name = "Marko"
                }
            };

            this.Locations = new LocationCreateModel[]
            {
                new LocationCreateModel
                {
                    MarketplaceName = "Maxi",
                    SiteName = "Sample Site Name",
                    Address = "Sample Address",
                    Postalcode = "12345",
                    Pib = "123456789",
                    IdNumber = "1234",
                    Work = "Sample work",
                    DomicileBankAccount = "123-4567891011121-48",
                    ChanelSales = "Sample",
                    IsAvailableForSelling = true,
                    IsContainHyphen = true
                },
                new LocationCreateModel
                {
                    MarketplaceName = "Delhaize",
                    SiteName = "Sample Site Name",
                    Address = "Sample Address",
                    Postalcode = "12345",
                    Pib = "123456789",
                    IdNumber = "1234",
                    Work = "Sample work",
                    DomicileBankAccount = "123-4567891011121-48",
                    ChanelSales = "Sample",
                    IsAvailableForSelling = true,
                    IsContainHyphen = true
                },
                new LocationCreateModel
                {
                    MarketplaceName = "Univerexport",
                    SiteName = "Sample Site Name",
                    Address = "Sample Address",
                    Postalcode = "12345",
                    Pib = "123456789",
                    IdNumber = "1234",
                    Work = "Sample work",
                    DomicileBankAccount = "123-4567891011121-48",
                    ChanelSales = "Sample",
                    IsAvailableForSelling = true,
                    IsContainHyphen = true
                },
                new LocationCreateModel
                {
                    MarketplaceName = "Aman",
                    SiteName = "Sample Site Name",
                    Address = "Sample Address",
                    Postalcode = "12345",
                    Pib = "123456789",
                    IdNumber = "1234",
                    Work = "Sample work",
                    DomicileBankAccount = "123-4567891011121-48",
                    ChanelSales = "Sample",
                    IsAvailableForSelling = true,
                    IsContainHyphen = true
                },
                new LocationCreateModel
                {
                    MarketplaceName = "Tempo",
                    SiteName = "Sample Site Name",
                    Address = "Sample Address",
                    Postalcode = "12345",
                    Pib = "123456789",
                    IdNumber = "1234",
                    Work = "Sample work",
                    DomicileBankAccount = "123-4567891011121-48",
                    ChanelSales = "Sample",
                    IsAvailableForSelling = true,
                    IsContainHyphen = true
                }
            };

            this.Storages = new StorageCreateModel[]
            {
                new StorageCreateModel
                {
                    Name = "Glavno skladiste",
                    Location = "Beograd"
                },
                new StorageCreateModel
                {
                    Name = "Skladiste Pancevo",
                    Location = "Pancevo"
                },
                new StorageCreateModel
                {
                    Name = "Skladiste Novi Sad",
                    Location = "Novi Sad"
                },
                new StorageCreateModel
                {
                    Name = "Skladiste Kragujevac",
                    Location = "Kragujevac"
                },
                new StorageCreateModel
                {
                    Name = "Skladiste Valjevo",
                    Location = "Valjevo"
                }
            };

            this.SellingPrograms = new SellingProgramCreateModel[]
            {
                new SellingProgramCreateModel
                {
                    SellingProgram = "Selling Program 1",
                    SellingCondition = "Selling Condition 1",
                    DayForPaying = 30
                },
                new SellingProgramCreateModel
                {
                    SellingProgram = "Selling Program 2",
                    SellingCondition = "Selling Condition 2",
                    DayForPaying = 35
                },
                new SellingProgramCreateModel
                {
                    SellingProgram = "Selling Program 3",
                    SellingCondition = "Selling Condition 3",
                    DayForPaying = 40
                },
                new SellingProgramCreateModel
                {
                    SellingProgram = "Selling Program 4",
                    SellingCondition = "Selling Condition 4",
                    DayForPaying = 45
                },
                new SellingProgramCreateModel
                {
                    SellingProgram = "Selling Program 5",
                    SellingCondition = "Selling Condition 5",
                    DayForPaying = 60
                }
            };

            this.SalesChannels = new SalesChannelCreateModel[]
            {
                new SalesChannelCreateModel
                {
                    Name = "Trgovine",
                    Description = "Samostalna trgovinska radnja"
                },
                new SalesChannelCreateModel
                { 
                    Name = "Kafici",
                    Description = "Samostalna usluzna radnja"
                }
            };

            this.Contacts = new ContactCreateModel[]
            {
                new ContactCreateModel
                {
                    Email = "sample.mail1@email.com",
                    Phone = "116189161",
                },
                new ContactCreateModel
                {
                    Email = "sample.mail2@hotmail.com",
                    Phone = "1619861611",
                },
                new ContactCreateModel
                {
                    Email = "sample.mail3@yahoo.com",
                    Phone = "19813156432",
                },
                new ContactCreateModel
                {
                    Email = "sample.mail4@outlook.com",
                    Phone = "94894416165",
                },
                new ContactCreateModel
                {
                    Email = "sample.mail5@mail.com",
                    Phone = "94894416165",
                }
            };

            this.Invoices = new InvoiceCreateModel[]
            {
                new InvoiceCreateModel
                {
                    InvoiceItems = new InvoiceItemCreateModel[]
                    {
                        new InvoiceItemCreateModel
                        {
                            Amount = 10,
                            DiscountBasic = 0.035
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 18,
                            DiscountBasic = 0.041
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 23,
                            DiscountBasic = 0.056
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 16,
                            DiscountBasic = 0.021
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 8,
                            DiscountBasic = 0.01
                        }
                    }
                },
                new InvoiceCreateModel
                {
                    InvoiceItems = new InvoiceItemCreateModel[]
                    {
                        new InvoiceItemCreateModel
                        {
                            Amount = 15,
                            DiscountBasic = 0.031
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 10,
                            DiscountBasic = 0.028
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 17,
                            DiscountBasic = 0.033
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 21,
                            DiscountBasic = 0.087
                        }
                    }
                },
                new InvoiceCreateModel
                {
                    InvoiceItems = new InvoiceItemCreateModel[]
                    {
                        new InvoiceItemCreateModel
                        {
                            Amount = 23,
                            DiscountBasic = 0.052
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 10,
                            DiscountBasic = 0.012
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 17,
                            DiscountBasic = 0.047
                        }
                    }
                },
                new InvoiceCreateModel
                {
                    InvoiceItems = new InvoiceItemCreateModel[]
                    {
                        new InvoiceItemCreateModel
                        {
                            Amount = 12,
                            DiscountBasic = 0.024
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 17,
                            DiscountBasic = 0.037
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 13,
                            DiscountBasic = 0.0442
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 8,
                            DiscountBasic = 0.058
                        }
                    }
                },
                new InvoiceCreateModel
                {
                    InvoiceItems = new InvoiceItemCreateModel[]
                    {
                        new InvoiceItemCreateModel
                        {
                            Amount = 16,
                            DiscountBasic = 0.0325
                        },
                        new InvoiceItemCreateModel
                        {
                            Amount = 7,
                            DiscountBasic = 0.073
                        }
                    }
                }
            };

            this.Orders = new OrderCreateModel[]
            {
                new OrderCreateModel
                {
                    orderItems = new OrderItemCreateModel[]
                    {
                        new OrderItemCreateModel
                        {
                            Amount = 12,
                            DiscountBasic = 0.05,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 12,
                            DiscountBasic = 0.07,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 20,
                            DiscountBasic = 0.03,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 25,
                            DiscountBasic = 0.03,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 20,
                            DiscountBasic = 0.03,
                        }
                    }
                },
                new OrderCreateModel
                {
                    orderItems = new OrderItemCreateModel[]
                    {
                        new OrderItemCreateModel
                        {
                            Amount = 16,
                            DiscountBasic = 0.032,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 18,
                            DiscountBasic = 0.047,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 22,
                            DiscountBasic = 0.093,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 13,
                            DiscountBasic = 0.0423,
                        }             
                    }
                },
                new OrderCreateModel
                {
                    orderItems = new OrderItemCreateModel[]
                    {
                        new OrderItemCreateModel
                        {
                            Amount = 19,
                            DiscountBasic = 0.0487,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 28,
                            DiscountBasic = 0.0291,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 11,
                            DiscountBasic = 0.0721,
                        }
                    }
                },
                new OrderCreateModel
                {
                    orderItems = new OrderItemCreateModel[]
                    {
                        new OrderItemCreateModel
                        {
                            Amount = 17,
                            DiscountBasic = 0.023,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 13,
                            DiscountBasic = 0.058,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 27,
                            DiscountBasic = 0.105,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 19,
                            DiscountBasic = 0.0763,
                        }
                    }
                },
                new OrderCreateModel
                {
                    orderItems = new OrderItemCreateModel[]
                    {
                        new OrderItemCreateModel
                        {
                            Amount = 22,
                            DiscountBasic = 0.038,
                        },
                        new OrderItemCreateModel
                        {
                            Amount = 15,
                            DiscountBasic = 0.075,
                        }
                    }
                }
            };
        }
    }
}
