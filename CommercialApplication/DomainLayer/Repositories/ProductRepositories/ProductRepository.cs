using CommercialApplication.DomainLayer.Entities.ProductEntities;
using CommercialApplication.DomainLayer.Repositories.CommandRequests;
using CommercialApplication.DomainLayer.Repositories.Commands.ProductCommands;
using CommercialApplication.DomainLayer.Repositories.ProductRepositories;
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
    public class ProductRepository : ProductBaseRepository, IProductRepository
    {

        public Product SelectById(IDbConnection connection, Id id, IDbTransaction transaction = null)
        {
            /*return connection.Query<Product>(ProductQueries.SelectById, new { id = id.Content }).Single();*/
            GetProductCommand command = (GetProductCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.Get];
            return command.Execute(connection, id, transaction);
        }

        public IEnumerable<Product> Select(IDbConnection connection, IDbTransaction transaction = null)
        {
            /*return connection.Query<Product>(ProductQueries.Select);*/
            GetAllProductCommand command = (GetAllProductCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.GetAll];
            return command.Execute(connection, transaction);
        }

        public IEnumerable<Product> SelectAllFruits(IDbConnection connection, IDbTransaction transaction = null)
        {
            /*return connection.Query<Product>(ProductQueries.SelectAllFruits);*/
            GetAllProductCommand command = (GetAllProductCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.GetAll];
            return command.Execute(connection, transaction);
        }

        public IEnumerable<Product> SelectAllVegetables(IDbConnection connection, IDbTransaction transaction = null)
        {
            /*return connection.Query<Product>(ProductQueries.SelectAllVegetables);*/
            GetAllVegetablesCommand command = (GetAllVegetablesCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.GetAllVegetables];
            return command.Execute(connection, transaction);
        }

        public Product SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            /*return connection.Query<Product>(ProductQueries.SelectByName, new { name = name.Content }).Single();*/
            GetProductCommandByName command = (GetProductCommandByName)this.commandProductCaller.DictCommands[ProductCommandRequests.GetByName];
            return command.Execute(connection, name, transaction);
        }

        public void Insert(IDbConnection connection, Product product, IDbTransaction transaction = null)
        {
            /*connection.Execute(ProductQueries.Insert, new
            {
                Name = product.Name.Content,
                UnitCost = product.UnitCost.ToString(),
                Description = product.Description.Content,
                ImageUrl = product.ImageUrl.Content,
                VideoLink = product.VideoLink.Content,
                SerialNumber = product.SerialNumber.Content
            });*/
            InsertProductCommand command = (InsertProductCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.Insert];
            command.Execute(connection, product, transaction);
        }

        public void Update(IDbConnection connection, Product product, IDbTransaction transaction = null)
        {
            /*connection.Execute(ProductQueries.Update, new
            {
                Name = product.Name.Content,
                UnitCost = product.UnitCost.ToString(),
                Description = product.Description.Content,
                ImageUrl = product.ImageUrl.Content,
                VideoLink = product.VideoLink.Content,
                id = product.Id
            });*/
            UpdateProductCommand command = (UpdateProductCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.Update];
            command.Execute(connection, product, transaction);
        }

        public void Delete(IDbConnection connection, Product product, IDbTransaction transaction = null)
        {
            /*connection.Execute(ProductQueries.Delete, new { id = product.Id });*/
            DeleteProductCommand command = (DeleteProductCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.Delete];
            command.Execute(connection, product, transaction);
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(ProductQueries.Exists, new { id });
        }

        public void UpdateFruitsUnitCost(IDbConnection connection, DecreaseFruitsUnitCost decreaseFruitsUnitCost, IDbTransaction transaction = null)
        {
            UpdateFruitsUnitCostCommand command = (UpdateFruitsUnitCostCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.UpdateFruits];
            command.Execute(connection, decreaseFruitsUnitCost, transaction);
        }

        public void UpdateVegetablesUnitCost(IDbConnection connection, DecreaseVegetablesUnitCost decreaseVegetablesUnitCost, IDbTransaction transaction = null)
        {
            UpdateVegetablesUnitCostCommand command = (UpdateVegetablesUnitCostCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.UpdateVegetables];
            command.Execute(connection, decreaseVegetablesUnitCost, transaction);
        }

        public void UpdateState(IDbConnection connection, ProductState productState, IDbTransaction transaction = null)
        {
            UpdateProductStateCommand command = (UpdateProductStateCommand)this.commandProductCaller.DictCommands[ProductCommandRequests.UpdateState];
            command.Execute(connection, productState, transaction);
        }
    }
}