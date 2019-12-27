using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories
{
    public interface IInvoiceRepository : IRepository
    {
        long Insert(IDbConnection connection, Invoice invoice, IDbTransaction transaction = null);
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}