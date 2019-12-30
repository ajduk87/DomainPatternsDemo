using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.InvoicesServices
{
    public class InvoiceCustomerService : IInvoiceCustomerService
    {
        private readonly IInvoiceCustomerRepository invoiceCustomerRepository;

        public InvoiceCustomerService()
        {
            this.invoiceCustomerRepository = RepositoryFactory.CreateInvoiceCustomerRepository();
        }

        public Customer SelectByInvoiceId(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return invoiceCustomerRepository.SelectByInvoiceId(connection, id);
        }

        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            this.invoiceCustomerRepository.Delete(connection, id);
        }

        public void Insert(IDbConnection connection, InvoiceCustomer invoiceCustomer, IDbTransaction transaction = null)
        {
            this.invoiceCustomerRepository.Insert(connection, invoiceCustomer);
        }
    }
}