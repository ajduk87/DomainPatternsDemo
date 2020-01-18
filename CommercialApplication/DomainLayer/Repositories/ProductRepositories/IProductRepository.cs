using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories
{
    public interface IProductRepository : IRepository
    {
        IEnumerable<IProduct> Select(IDbConnection connection, IDbTransaction transaction = null);
        IEnumerable<IProduct> SelectAllFruits(IDbConnection connection, IDbTransaction transaction = null);
        IEnumerable<IProduct> SelectAllVegetables(IDbConnection connection, IDbTransaction transaction = null);
        IProduct SelectById(IDbConnection connection, Id id, IDbTransaction transaction = null);
        IProduct SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null);

        void Insert(IDbConnection connection, IProduct product, IDbTransaction transaction = null);

        void Update(IDbConnection connection, IProduct product, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, IProduct product, IDbTransaction transaction = null);

        bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null);
    }
}