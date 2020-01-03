using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ActionCommands
{
    public class UpdateActionCommandByCustomerId : IActionCommand
    {
        public void Execute(NpgsqlConnection connection, Action actionEntity, IDbTransaction transaction = null)
        {
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("update_action_bycustomerid", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("productid", actionEntity.ProductId);
            command.Parameters.AddWithValue("discount", actionEntity.Discount);
            command.Parameters.AddWithValue("thresholdamount", actionEntity.ThresholdAmount);
            command.Parameters.AddWithValue("criteriacustomerid", actionEntity.CustomerId);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
