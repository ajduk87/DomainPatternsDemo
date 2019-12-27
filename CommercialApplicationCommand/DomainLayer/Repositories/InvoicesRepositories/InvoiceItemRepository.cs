using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories
{
    public class InvoiceItemRepository : IInvoiceItemRepository
    {
        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(InvoiceItemQueries.Delete, new { id });
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(InvoiceItemQueries.Exists, new { id });
        }

        public long Insert(IDbConnection connection, InvoiceItem invoiceItem, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<long>(InvoiceItemQueries.Insert, new
            {
                productId = invoiceItem.ProductId.Content,
                amount = invoiceItem.Amount.Content,
                value = invoiceItem.Value.Value,
                discountBasic = invoiceItem.DiscountBasic.Content,
                actionId = invoiceItem.ActionId.Content
            });
        }
    }
}