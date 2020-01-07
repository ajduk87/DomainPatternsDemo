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
    public class UpdateVegetablesUnitCostCommand : CommandBase, IProductCommand
    {
        public void Execute(IDbConnection conn, DecreaseVegetablesUnitCost decreaseVegetablesUnitCost, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("update_vegetables", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("percent", decreaseVegetablesUnitCost.Percent.Content);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
