using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories
{
    public interface IInvoiceItemInvoicesRepository : IRepository
    {
        void Insert(IDbConnection connection, InvoiceItemInvoice invoiceItemInvoice, IDbTransaction transcation = null);
        void Delete(IDbConnection connection, long id, IDbTransaction transcation = null);
        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<long> SelectByInvoiceId(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}