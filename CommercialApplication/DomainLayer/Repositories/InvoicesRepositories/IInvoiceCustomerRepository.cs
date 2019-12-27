using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories
{
    public interface IInvoiceCustomerRepository : IRepository
    {
        void Insert(IDbConnection connection, InvoiceCustomer invoiceCustomer, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}