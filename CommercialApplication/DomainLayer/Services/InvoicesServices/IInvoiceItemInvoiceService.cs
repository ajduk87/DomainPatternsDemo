using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.InvoicesServices
{
    public interface IInvoiceItemInvoiceService
    {
        void Insert(IDbConnection connection, InvoiceItemInvoice invoiceItemInvoice, IDbTransaction transaction = null);
        void InsertList(IDbConnection connection, IEnumerable<InvoiceItem> invoiceItems, long invoiceId, IDbTransaction transaction = null);
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);
        IEnumerable<long> SelectByInvoiceId(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}