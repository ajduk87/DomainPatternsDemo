using CommercialApplication.DomainLayer.Repositories.CommandRequests;
using CommercialApplication.DomainLayer.Repositories.Commands.Callers;
using CommercialApplication.DomainLayer.Repositories.Commands.StorageCommands;
using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
using CommercialApplicationCommand.DomainLayer.Entities.StorageEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.StorageRepositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly CommandStorageCaller commandStorageCaller;

        public StorageRepository()
        {
            this.commandStorageCaller = new CommandStorageCaller();
        }

        public void Delete(IDbConnection connection, Storage storage, IDbTransaction transaction = null)
        {
            /*connection.Execute(StorageQueries.Delete, new { id = storage.Id });*/
            DeleteStorageCommand command = (DeleteStorageCommand)this.commandStorageCaller.DictCommands[StorageCommandRequests.Delete];
            command.Execute(connection, storage, transaction);
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return connection.ExecuteScalar<bool>(StorageQueries.Exists, new { id });
        }

        public void Insert(IDbConnection connection, Storage storage, IDbTransaction transaction = null)
        {
            /*connection.Execute(StorageQueries.Insert, new
            {
                Name = storage.Name.Content,
                Location = storage.LocationOfStorage.Content
            });*/
            InsertStorageCommand command = (InsertStorageCommand)this.commandStorageCaller.DictCommands[StorageCommandRequests.Insert];
            command.Execute(connection, storage, transaction);
        }

        public IEnumerable<Storage> Select(IDbConnection connection, IDbTransaction transaction = null)
        {
            /*return connection.Query<Storage>(StorageQueries.Select);*/
            GetAllStorageCommand command = (GetAllStorageCommand)this.commandStorageCaller.DictCommands[StorageCommandRequests.GetAll];
            return command.Execute(connection, transaction);
        }

        public Storage SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            /*return connection.Query<Storage>(StorageQueries.SelectByName, new { Name = name.Content }).Single();*/
            GetStorageByNameCommand command = (GetStorageByNameCommand)this.commandStorageCaller.DictCommands[StorageCommandRequests.GetByName];
            return command.Execute(connection, name, transaction);
        }

        public void Update(IDbConnection connection, Storage storage, IDbTransaction transaction = null)
        {
            /*connection.Execute(StorageQueries.Update, new
            {
                id = storage.Id,
                Name = storage.Name.Content,
                Location = storage.LocationOfStorage.Content
            });*/
            UpdateStorageCommand command = (UpdateStorageCommand)this.commandStorageCaller.DictCommands[StorageCommandRequests.Update];
            command.Execute(connection, storage, transaction);
        }
    }
}