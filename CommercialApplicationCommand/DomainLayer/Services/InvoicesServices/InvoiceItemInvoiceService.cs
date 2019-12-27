using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
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
    }
}