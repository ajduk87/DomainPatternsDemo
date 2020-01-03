using Npgsql;
using System.Data;
using Action = CommercialApplicationCommand.DomainLayer.Entities.ActionEntities.Action;

namespace CommercialApplication.DomainLayer.Repositories.Commands.ActionCommands
{
    public class InsertActionCommand : IActionCommand
    {
        public void Execute(NpgsqlConnection connection, Action actionEntity, IDbTransaction transaction = null)
        {
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("insert_action", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("productid", actionEntity.ProductId);
            command.Parameters.AddWithValue("discount", actionEntity.Discount);
            command.Parameters.AddWithValue("thresholdamount", actionEntity.ThresholdAmount);
            command.Parameters.AddWithValue("customerid", actionEntity.CustomerId);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}