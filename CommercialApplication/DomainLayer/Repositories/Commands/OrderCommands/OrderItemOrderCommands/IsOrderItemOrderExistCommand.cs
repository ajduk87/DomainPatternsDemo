using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderItemOrderCommands
{
    public class IsOrderItemOrderExistCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "isexist_orderitemorder_byid";

        public bool Execute(IDbConnection conn, long id, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;

            // Execute the procedure and obtain a result set
            bool isExist = (bool)command.ExecuteScalar();

            return isExist;
        }
    }
}
