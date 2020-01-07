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
    public class GetAllStorageCommand : CommandBase, IStorageCommand
    {
        public string StoredFunctionName { get; } = "select_storage";

        public IEnumerable<Storage> Execute(IDbConnection conn, IDbTransaction transaction = null)
        {
            List<Storage> storages = new List<Storage>();

            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Storage storage = new Storage
                {
                    Id = new Id(Convert.ToInt64(dr["Id"].ToString())),
                    Name = new Name(dr["Name"].ToString()),
                    LocationOfStorage = new LocationOfStorage(dr["Location"].ToString())
                };

                storages.Add(storage);
            }

            connection.Close();

            return storages;
        }
    }
}
