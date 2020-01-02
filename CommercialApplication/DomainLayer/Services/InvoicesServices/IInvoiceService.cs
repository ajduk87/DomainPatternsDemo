using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.InvoicesServices
{
    public interface IInvoiceService
    {
        Invoice SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<Invoice> SelectByDay(IDbConnection connection, string day, IDbTransaction transaction = null);
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, Invoice invoice, IDbTransaction transaction = null);

        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
        long SelectInvoiceIdWithMaxSumValueByDay(IDbConnection connection, IEnumerable<Invoice> invoices, IDbTransaction transaction = null);
        long SelectInvoiceIdWithMinSumValueByDay(IDbConnection connection, IEnumerable<Invoice> invoices, IDbTransaction transaction = null);
    }
}