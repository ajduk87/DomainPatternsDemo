using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderCustomerCommands
{
    public class UpdateOrderCustomerCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "update_ordercustomer";

        public void Execute(IDbConnection conn, OrderCustomer orderCustomer, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("orderCustomer", orderCustomer);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
