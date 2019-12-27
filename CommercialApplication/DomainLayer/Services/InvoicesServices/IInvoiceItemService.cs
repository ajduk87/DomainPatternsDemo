using CommercialApplicationCommand.DomainLayer.Entities.CommonEntities;
using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.InvoicesServices
{
    public interface IInvoiceItemService
    {
        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);

        long Insert(IDbConnection connection, InvoiceItem invoiceItem, IDbTransaction transaction = null);

        Money IncludeBasicDiscountForPaying(IDbConnection connection, InvoiceItem invoiceItem, IDbTransaction transaction = null);
    }
}