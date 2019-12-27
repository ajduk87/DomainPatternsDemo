using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories
{
    public class InvoiceCustomerRepository : IInvoiceCustomerRepository
    {
        public void Delete(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            connection.Execute(InvoiceCustomerQueries.Delete, new { invoiceId = id });
        }

        public void Insert(IDbConnection connection, InvoiceCustomer invoiceCustomer, IDbTransaction transaction = null)
        {
            connection.Execute(InvoiceCustomerQueries.Insert, new
            {
                invoiceId = invoiceCustomer.InvoiceId.Content,
                customerId = invoiceCustomer.CustomerId.Content
            });
        }
    }
}