using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.InvoicesServices
{
    public interface IInvoiceCustomerService
    {
        Customer SelectByInvoiceId(IDbConnection connection, long id, IDbTransaction transaction = null);
        void Insert(IDbConnection connection, InvoiceCustomer invoiceCustomer, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}