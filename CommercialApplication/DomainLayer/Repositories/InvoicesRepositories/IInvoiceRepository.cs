using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories
{
    public interface IInvoiceRepository : IRepository
    {
        Invoice SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<Invoice> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, Invoice invoice, IDbTransaction transaction = null);
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}