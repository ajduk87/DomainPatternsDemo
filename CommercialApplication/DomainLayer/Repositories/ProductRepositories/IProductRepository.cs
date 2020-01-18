using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories
{
    public interface /* IProduct */ AProductRepository : IRepository
    {
        IEnumerable</* IProduct */ AProduct> Select(IDbConnection connection, IDbTransaction transaction = null);
        IEnumerable</* IProduct */ AProduct> SelectAllFruits(IDbConnection connection, IDbTransaction transaction = null);
        IEnumerable</* IProduct */ AProduct> SelectAllVegetables(IDbConnection connection, IDbTransaction transaction = null);
        /* IProduct */ AProduct SelectById(IDbConnection connection, Id id, IDbTransaction transaction = null);
        /* IProduct */ AProduct SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null);

        void Insert(IDbConnection connection, /* IProduct */ AProduct product, IDbTransaction transaction = null);

        void Update(IDbConnection connection, /* IProduct */ AProduct product, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, /* IProduct */ AProduct product, IDbTransaction transaction = null);

        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}