using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands
{
    public class UpdateListOrderItemCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "updatelist_orderitem";

        public void Execute(IDbConnection conn, IEnumerable<OrderItem> orderItems, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("orderitems", orderItems);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
