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
    public class DeleteProductFromStorageCommand : CommandBase, IProductCommand
    {
        public void Execute(IDbConnection conn, ProductStorage productStorage, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("delete_product_fromstorage", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("criteriaproductid", productStorage.ProductId);
            command.Parameters.AddWithValue("criteriastorageid", productStorage.StorageId);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
