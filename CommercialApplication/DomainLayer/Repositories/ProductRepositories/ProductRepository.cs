using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Product;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        public IProduct SelectById(IDbConnection connection, Id id, IDbTransaction transaction = null)
        {
            return connection.Query<IProduct>(ProductQueries.SelectById, new { id = id.Content }).Single();
        }

        public IEnumerable<IProduct> Select(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<IProduct>(ProductQueries.Select);
        }

        public IEnumerable<IProduct> SelectAllFruits(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<IProduct>(ProductQueries.SelectAllFruits);
        }

        public IEnumerable<IProduct> SelectAllVegetables(IDbConnection connection, IDbTransaction transaction = null)
        {
            return connection.Query<IProduct>(ProductQueries.SelectAllVegetables);
        }

        public IProduct SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            return connection.Query<IProduct>(ProductQueries.SelectByName, new { name = name.Content }).Single();
        }

        public void Insert(IDbConnection connection, IProduct product, IDbTransaction transaction = null)
        {
            connection.Execute(ProductQueries.Insert, new
            {
                Name = product.Name.Content,
                UnitCost = product.UnitCost.ToString(),
                Description = product.Description.Content,
                ImageUrl = product.ImageUrl.Content,
                VideoLink = product.VideoLink.Content,
                SerialNumber = product.SerialNumber.Content
            });
        }

        public void Update(IDbConnection connection, IProduct product, IDbTransaction transaction = null)
        {
            connection.Execute(ProductQueries.Update, new
            {
                Name = product.Name.Content,
                UnitCost = product.UnitCost.ToString(),
                Description = product.Description.Content,
                ImageUrl = product.ImageUrl.Content,
                VideoLink = product.VideoLink.Content,
                id = product.Id
            });
        }

        public void Delete(IDbConnection connection, IProduct product, IDbTransaction transaction = null)
        {
            connection.Execute(ProductQueries.Delete, new { id = product.Id });
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(ProductQueries.Exists, new { id });
        }
    }
}