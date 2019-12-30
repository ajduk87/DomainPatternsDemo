using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public Invoice SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.Query<Invoice>(InvoicesQueries.SelectById, new { id }).Single();
        }

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