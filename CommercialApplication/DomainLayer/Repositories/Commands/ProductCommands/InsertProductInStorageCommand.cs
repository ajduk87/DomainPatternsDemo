using CommercialApplicationCommand.DomainLayer.Entities.ProductEntities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ProductCommands
{
    public class InsertProductInStorageCommand : CommandBase, IProductCommand
    {
        public string StoredFunctionName { get; } = "insert_storageitem";

        public void Execute(IDbConnection conn, ProductStorage productStorage, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("productId", productStorage.ProductId);
            command.Parameters.AddWithValue("storageid", productStorage.StorageId);
            command.Parameters.AddWithValue("amountofproduct", productStorage.AmountOfProduct);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
