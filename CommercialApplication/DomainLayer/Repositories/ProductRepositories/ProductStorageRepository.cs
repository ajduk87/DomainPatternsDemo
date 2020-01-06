using CommercialApplication.DomainLayer.Repositories.CommandRequests;
using CommercialApplication.DomainLayer.Repositories.Commands.ProductCommands;
using CommercialApplication.DomainLayer.Repositories.ProductRepositories;
using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Repositories.ProductRepositories
{
    public class ProductStorageRepository : ProductBaseRepository, IProductStorageRepository
    {
        public ProductStorageRepository()
        {
        }

        public IEnumerable<ProductStorage> SelectProductFromAllStorages(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.Query<ProductStorage>(ProductStorageQueries.SelectByProductFromAllStorages, new { productId = id });*/
            GetProductFromAllStoragesCommand command = (GetProductFromAllStoragesCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.GetProductFromAllStorages];
            return command.Execute(connection, id, transaction);
        }

        public IEnumerable<ProductStorage> SelectByStorageId(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.Query<ProductStorage>(ProductStorageQueries.SelectByStorageId, new { storageId = id});*/
            GetAllProductsFromStorageCommand command = (GetAllProductsFromStorageCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.GetAllProductsFromStorage];
            return command.Execute(connection, id, transaction);
        }

        public void Delete(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null)
        {
            DeleteProductFromStorageCommand command = (DeleteProductFromStorageCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.DeleteProductFromStorage];
            command.Execute(connection, productStorage, transaction);
            /*connection.Execute(ProductStorageQueries.Delete, new
            {
                productId = productStorage.ProductId.Content,
                storageId = productStorage.StorageId.Content
            });*/
        }

        public void Insert(IDbConnection connection, ProductStorage productStorage, IDbTransaction transaction = null)
        {
            InsertProductInStorageCommand command = (InsertProductInStorageCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.InsertProductInStorage];
            command.Execute(connection, productStorage, transaction);
            /*connection.Execute(ProductStorageQueries.Insert, new
            {
                productId = productStorage.ProductId.Content,
                storageId = productStorage.StorageId.Content,
                amountOfProduct = productStorage.AmountOfProduct.Content
            });*/
        }
    }
}