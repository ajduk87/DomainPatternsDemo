using CommercialApplicationCommand.DomainLayer.Entities.StorageEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Storage;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.StorageCommands
{
    public class GetStorageByNameCommand : CommandBase, IStorageCommand
    {
        public Storage Execute(IDbConnection conn, Name name, IDbTransaction transaction = null)
        {
            Storage storage = new Storage();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("select_storage_byname", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("criterianame", name.Content);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                storage = new Storage
                {
                    Id = new Id(Convert.ToInt64(dr["Id"].ToString())),
                    Name = new Name(dr["Name"].ToString()),
                    LocationOfStorage = new LocationOfStorage(dr["Location"].ToString())
                };
            }

            connection.Close();

            return storage;
        }
    }
}
