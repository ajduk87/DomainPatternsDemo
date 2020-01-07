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
    public class InsertProductCommand : CommandBase, IProductCommand
    {
        public string StoredFunctionName { get; } = "insert_product";

        public void Execute(IDbConnection conn, Product product, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("name", product.Name);
            command.Parameters.AddWithValue("unitcost", product.UnitCost);
            command.Parameters.AddWithValue("description", product.Description);
            command.Parameters.AddWithValue("imageurl", product.ImageUrl);
            command.Parameters.AddWithValue("videolink", product.VideoLink);
            command.Parameters.AddWithValue("serialnumber", product.SerialNumber);
            command.Parameters.AddWithValue("state", product.State);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
