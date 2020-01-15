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
    public class GetOrdersByDayCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "select_orders_byday";

        public IEnumerable<Order> Execute(IDbConnection conn, string day, IDbTransaction transaction = null)
        {
            List<Order> orders = new List<Order>();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("criteriaday", day);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Order order = new Order
                {
                    Id = new Id(Convert.ToInt64(dr["orderid"].ToString())),
                    State = new State(dr["state"].ToString()),
                    CreationDate = new CreationDate(dr["creationDate"].ToString())
                };

                orders.Add(order);
            }

            connection.Close();

            return orders;
        }
    }
}
