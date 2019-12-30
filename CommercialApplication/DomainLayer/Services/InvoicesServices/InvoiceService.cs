using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.InvoicesServices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoicesRepository;

        public InvoiceService()
        {
            this.invoicesRepository = RepositoryFactory.CreateInvoiceRepository();
        }

        public Invoice SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.invoicesRepository.SelectById(connection, id);
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