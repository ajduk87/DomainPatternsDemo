using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(InvoicesQueries.Delete, new { id });
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(InvoicesQueries.Exists, new { id });
        }

        public long Insert(IDbConnection connection, Invoice invoice, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<long>(InvoicesQueries.Insert, new
            {
                sellingProgramId = invoice.SellingProgramId.Content,
            });
        }
    }
}