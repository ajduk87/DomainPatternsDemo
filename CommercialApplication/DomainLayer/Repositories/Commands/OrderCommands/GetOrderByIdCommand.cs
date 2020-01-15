using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.OrderEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands
{
    public class GetOrderByIdCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "select_order_byid";

        public Order Execute(IDbConnection conn, long id, IDbTransaction transaction = null)
        {
            Order order = new Order();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("criteriaid", id);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                order = new Order
                {
                    Id = new Id(Convert.ToInt64(dr["orderid"].ToString())),
                    State = new State(dr["state"].ToString()),
                    CreationDate = new CreationDate(dr["creationDate"].ToString())
                };
            }

            connection.Close();

            return order;
        }
    }
}
