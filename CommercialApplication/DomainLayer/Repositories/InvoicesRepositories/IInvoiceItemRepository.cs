﻿using CommercialApplicationCommand.DomainLayer.Entities.InvoicesEntities;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.InvoicesRepositories
{
    public interface IInvoiceItemRepository : IRepository
    {
        InvoiceItem SelectById(IDbConnection connection, long invoiceId, IDbTransaction transaction = null);
        long Insert(IDbConnection connection, InvoiceItem invoiceItem, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, long id, IDbTransaction transaction = null);

        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}