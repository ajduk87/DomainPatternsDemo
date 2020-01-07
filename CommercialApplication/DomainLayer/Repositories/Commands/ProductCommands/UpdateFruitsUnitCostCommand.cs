using CommercialApplication.DomainLayer.Entities.ProductEntities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ProductCommands
{
    public class UpdateFruitsUnitCostCommand : CommandBase, IProductCommand
    {
        public string StoredFunctionName { get; } = "update_fruits";

        public void Execute(IDbConnection conn, DecreaseFruitsUnitCost decreaseFruitsUnitCost, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("percent", decreaseFruitsUnitCost.Percent.Content);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
