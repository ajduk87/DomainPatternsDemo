using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories
{
    public class ProductStorageRepository : IProductStorageRepository
    {
        public void Delete(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null)
        {
            connection.Execute(ProductStorageQueries.Delete, new
            {
                productId = productStorage.ProductId.Content,
                storageId = productStorage.StorageId.Content
            });
        }

        public void Insert(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null)
        {
            connection.Execute(ProductStorageQueries.Insert, new
            {
                productId = productStorage.ProductId.Content,
                storageId = productStorage.StorageId.Content,
                amountOfProduct = productStorage.AmountOfProduct.Content
            });
        }
    }
}