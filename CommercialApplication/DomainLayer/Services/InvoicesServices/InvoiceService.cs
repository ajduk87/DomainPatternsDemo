using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Services.InvoicesServices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoicesRepository;
        private readonly IInvoiceItemRepository invoiceItemRepository;
        private readonly IInvoiceItemInvoicesRepository invoiceItemInvoicesRepository;

        public InvoiceService()
        {
            this.invoicesRepository = RepositoryFactory.CreateInvoiceRepository();
            this.invoiceItemRepository = RepositoryFactory.CreateInvoiceItemRepository();
            this.invoiceItemInvoicesRepository = RepositoryFactory.CreateInvoiceItemInvoicesRepository();
        }

        private double SumValue(IDbConnection connection, IEnumerable<InvoiceItem> invoiceItems, IDbTransaction transaction = null)
        {
            double invoiceSumValue = 0;
            foreach (InvoiceItem invoiceitem in invoiceItems)
            {
                invoiceSumValue = invoiceSumValue + invoiceitem.Value.Value;
            }
            return invoiceSumValue;
        }

        public Invoice SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.invoicesRepository.SelectById(connection, id);
        }

        public IEnumerable<Invoice> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null)
        {
            return this.invoicesRepository.SelectByDay(connection, day);
        }

        public long SelectInvoiceIdWithMaxSumValueByDay(IDbConnection connection, IEnumerable<Invoice> invoices, IDbTransaction transaction = null)
        {
            IEnumerable<long> invoiceItemsIds = this.invoiceItemInvoicesRepository.SelectByInvoiceId(connection, invoices.First().Id);
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach (long id in invoiceItemsIds)
            {
                InvoiceItem invoiceItem = this.invoiceItemRepository.SelectById(connection, id);
                invoiceItems.Add(invoiceItem);
            }
            double firstInvoiceSumValue = this.SumValue(connection, invoiceItems);


            long invoiceIdWithMaxSumValue = invoiceItemsIds.First();
            double invoiceMaxSumValue = firstInvoiceSumValue;


            for (int i = 1; i < invoices.Count(); i++)
            {
                double currentInvoiceSumValue = 0;
                IEnumerable<long> invoiceItemsIdsForCurrentInvoice = this.invoiceItemInvoicesRepository.SelectByInvoiceId(connection, invoices.First().Id);
                List<InvoiceItem> invoiceItemsForCurrentInvoice = new List<InvoiceItem>();
                foreach (long id in invoiceItemsIds)
                {
                    InvoiceItem invoiceItem = this.invoiceItemRepository.SelectById(connection, id);
                    invoiceItemsForCurrentInvoice.Add(invoiceItem);
                }
                currentInvoiceSumValue = this.SumValue(connection, invoiceItemsForCurrentInvoice);

                if (currentInvoiceSumValue > invoiceMaxSumValue)
                {
                    invoiceIdWithMaxSumValue = i;
                    invoiceMaxSumValue = currentInvoiceSumValue;
                }
            }
            return invoiceIdWithMaxSumValue;
        }

        public long SelectInvoiceIdWithMinSumValueByDay(IDbConnection connection, IEnumerable<Invoice> invoices, IDbTransaction transaction = null)
        {
            IEnumerable<long> invoiceItemsIds = this.invoiceItemInvoicesRepository.SelectByInvoiceId(connection, invoices.First().Id);
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            foreach (long id in invoiceItemsIds)
            {
                InvoiceItem invoiceItem = this.invoiceItemRepository.SelectById(connection, id);
                invoiceItems.Add(invoiceItem);
            }
            double firstInvoiceSumValue = this.SumValue(connection, invoiceItems);


            long invoiceIdWithMinSumValue = invoiceItemsIds.First();
            double invoiceMinSumValue = firstInvoiceSumValue;


            for (int i = 1; i < invoices.Count(); i++)
            {
                double currentInvoiceSumValue = 0;
                IEnumerable<long> invoiceItemsIdsForCurrentInvoice = this.invoiceItemInvoicesRepository.SelectByInvoiceId(connection, invoices.First().Id);
                List<InvoiceItem> invoiceItemsForCurrentInvoice = new List<InvoiceItem>();
                foreach (long id in invoiceItemsIds)
                {
                    InvoiceItem invoiceItem = this.invoiceItemRepository.SelectById(connection, id);
                    invoiceItemsForCurrentInvoice.Add(invoiceItem);
                }
                currentInvoiceSumValue = this.SumValue(connection, invoiceItemsForCurrentInvoice);

                if (currentInvoiceSumValue < invoiceMinSumValue)
                {
                    invoiceIdWithMinSumValue = i;
                    invoiceMinSumValue = currentInvoiceSumValue;
                }
            }
            return invoiceIdWithMinSumValue;
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            this.invoicesRepository.Delete(connection, id);
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.invoicesRepository.Exists(connection, id);
        }

        public long Insert(IDbConnection connection, Invoice invoice, IDbTransaction transaction = null)
        {
            return this.invoicesRepository.Insert(connection, invoice);
        }
    }
}