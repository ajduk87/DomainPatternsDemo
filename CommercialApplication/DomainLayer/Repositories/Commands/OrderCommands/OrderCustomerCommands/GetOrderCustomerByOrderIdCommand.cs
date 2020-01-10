using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.OrderCommands.OrderCustomerCommands
{
    public class GetOrderCustomerByOrderIdCommand : CommandBase, IOrderCommand
    {
        public string StoredFunctionName { get; } = "";

        public Customer Execute(IDbConnection conn, long id, IDbTransaction transaction = null)
        {
            Customer customer = new Customer();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("criteriaid", id);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                customer = new Customer
                {
                    Id = new Id(Convert.ToInt64(dr["orderitemid"].ToString())),
                    Name = new Name(dr["name"].ToString())
                };
            }

            connection.Close();

            return customer;
        }
    }
}
