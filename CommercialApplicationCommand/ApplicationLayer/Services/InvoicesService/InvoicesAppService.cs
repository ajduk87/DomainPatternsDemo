using System;
using System.Collections.Generic;
using Autofac;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Invoices;
using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Services.InvoicesServices;
using Npgsql;

namespace CommercialApplicationCommand.ApplicationLayer.Services.InvoicesService
{
    public class InvoicesAppService : BaseAppService, IInvoicesAppService
    {
        private readonly IInvoiceCustomerService invoiceCustomerService;
        private readonly IInvoiceItemInvoiceService invoiceItemInvoicesService;
        private readonly IInvoiceItemService invoiceItemService;
        private readonly IInvoiceService invoicesService;

        public InvoicesAppService()
        {
            this.invoicesService = this.registrationServices.Instance.Container.Resolve<IInvoiceService>();
            this.invoiceItemService = this.registrationServices.Instance.Container.Resolve<IInvoiceItemService>();
            this.invoiceItemInvoicesService = this.registrationServices.Instance.Container.Resolve<IInvoiceItemInvoiceService>();
            this.invoiceCustomerService = this.registrationServices.Instance.Container.Resolve<IInvoiceCustomerService>();
        }

        public void RemoveExistingInvoice(InvoiceDto invoiceDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                connection.Open();
                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        IEnumerable<long> invoiceItemIds = this.invoiceItemInvoicesService.SelectByInvoiceId(connection, invoiceDto.Id);
                        this.invoiceItemInvoicesService.Delete(connection, invoiceDto.Id);
                        this.invoiceCustomerService.Delete(connection, invoiceDto.Id);
                        foreach (long id in invoiceItemIds)
                        {
                            this.invoiceItemService.Delete(connection, id);
                        }
                        this.invoicesService.Delete(connection, invoiceDto.Id);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.Write(ex);
                    }
                }
            }
        }

        public void CreateNewInvoice(InvoiceDto invoiceDto)
        {
            using (NpgsqlConnection connection = this.databaseConnectionFactory.Instance.Create())
            {
                connection.Open();
                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        Invoice invoice = this.dtoToEntityMapper.Map<InvoiceDto, Invoice>(invoiceDto);
                        long invoiceId = this.invoicesService.Insert(connection, invoice);
                        InvoiceCustomerDto invoiceCustomerDto = new InvoiceCustomerDto
                        {
                            InvoiceId = invoiceId,
                            CustomerId = invoiceDto.CustomerId
                        };
                        InvoiceCommercialistDto invoiceCommercialistDto = new InvoiceCommercialistDto
                        {
                            InvoiceId = invoiceId,
                            CommercialistId = invoiceDto.CommercialistId
                        };
                        InvoiceCustomer invoiceCustomer = this.dtoToEntityMapper.Map<InvoiceCustomerDto, InvoiceCustomer>(invoiceCustomerDto);
                        InvoiceCommercialist invoiceCommercialist = this.dtoToEntityMapper.Map<InvoiceCommercialistDto, InvoiceCommercialist>(invoiceCommercialistDto);
                        this.invoiceCustomerService.Insert(connection, invoiceCustomer);
                        foreach (InvoiceItemDto invoiceItemDto in invoiceDto.InvoiceItems)
                        {
                            InvoiceItem invoiceItem = this.dtoToEntityMapper.Map<InvoiceItemDto, InvoiceItem>(invoiceItemDto);
                            invoiceItem.Value = this.invoiceItemService.IncludeBasicDiscountForPaying(connection, invoiceItem);
                            long invoiceItemId = this.invoiceItemService.Insert(connection, invoiceItem);
                            InvoiceItemInvoiceDto invoiceItemInvoiceDto = new InvoiceItemInvoiceDto
                            {
                                InvoiceId = invoiceId,
                                InvoiceItemId = invoiceItemId
                            };

                            InvoiceItemInvoice invoiceItemInvoice = this.dtoToEntityMapper.Map<InvoiceItemInvoiceDto, InvoiceItemInvoice>(invoiceItemInvoiceDto);
                            this.invoiceItemInvoicesService.Insert(connection, invoiceItemInvoice);
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.Write(ex.Message);
                    }
                }
            }
        }
    }
}