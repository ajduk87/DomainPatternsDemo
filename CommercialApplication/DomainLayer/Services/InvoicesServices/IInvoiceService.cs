using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.InvoicesServices
{
    public interface IInvoiceService
    {
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, Invoice invoice, IDbTransaction transaction = null);

        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}