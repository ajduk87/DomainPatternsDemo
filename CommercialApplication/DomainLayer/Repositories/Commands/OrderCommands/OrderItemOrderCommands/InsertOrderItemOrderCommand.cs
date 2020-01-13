using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderItemOrderCommands
{
    public class InsertOrderItemOrderCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "connect_orderitem_with_order";

        public void Execute(IDbConnection conn, IEnumerable<OrderItem> orderItems, long orderId, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("orderItems", orderItems);
            command.Parameters.AddWithValue("orderId", orderId);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
