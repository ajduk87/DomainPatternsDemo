using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.OrderItemOrder;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderItemOrderCommands
{
    public class GetOrderItemsOrderByOrderIdCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "select_orderitemids_byorderid";

        public IEnumerable<long> Execute(IDbConnection conn, long id, IDbTransaction transaction = null)
        {
            List<long> orderItemIds = new List<long>();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                long orderItemId = new OrderItemId(Convert.ToInt64(dr["orderitemid"].ToString()));

                orderItemIds.Add(orderItemId);
            }

            connection.Close();

            return orderItemIds;
        }
    }
}
