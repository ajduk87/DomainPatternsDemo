using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.InvoiceItemInvoice;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.InvoicesServices
{
    public class InvoiceItemInvoiceService : IInvoiceItemInvoiceService
    {
        private readonly IInvoiceItemInvoicesRepository invoiceItemInvoicesRepository;

        public InvoiceItemInvoiceService()
        {
            this.invoiceItemInvoicesRepository = RepositoryFactory.CreateInvoiceItemInvoicesRepository();
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            this.invoiceItemInvoicesRepository.Delete(connection, id);
        }

        public IEnumerable<long> SelectByInvoiceId(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.invoiceItemInvoicesRepository.SelectByInvoiceId(connection, id);
        }

        public void Insert(IDbConnection connection, InvoiceItemInvoice invoiceItemInvoice, IDbTransaction transaction = null)
        {
            this.invoiceItemInvoicesRepository.Insert(connection, invoiceItemInvoice);
        }

        public void InsertList(IDbConnection connection, IEnumerable<InvoiceItem> invoiceItems, long invoiceId, IDbTransaction transaction = null)
        {
            foreach (InvoiceItem invoiceItem in invoiceItems)
            {
                InvoiceItemInvoice invoiceItemInvoice = new InvoiceItemInvoice
                {
                    InvoiceItemId = new InvoiceItemId(invoiceItem.Id),
                    InvoiceId = new InvoiceId(invoiceId)
                };
                this.invoiceItemInvoicesRepository.Insert(connection, invoiceItemInvoice);
            }
        }
    }
}