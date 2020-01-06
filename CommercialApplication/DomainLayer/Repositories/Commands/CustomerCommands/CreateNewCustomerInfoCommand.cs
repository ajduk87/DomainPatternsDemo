using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.CustomerCommands
{
    public class CreateNewCustomerInfoCommand : CommandBase, ICustomerCommand
    {
        public void Execute(IDbConnection conn, Customer customer, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("insert_customer", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("name", customer.Name);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
