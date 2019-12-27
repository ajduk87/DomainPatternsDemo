using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
using CommercialApplicationCommand.DomainLayer.Entities.StorageEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Repositories.StorageRepositories;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.StorageServices
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository storageRepository = new StorageRepository();

        public void Delete(IDbConnection connection, Storage storage, IDbTransaction transaction = null) =>
            this.storageRepository.Delete(connection, storage);

        public void Insert(IDbConnection connection, Storage storage, IDbTransaction transaction = null) =>
            this.storageRepository.Insert(connection, storage);

        public StorageDto SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null)
        {
            return this.storageRepository.SelectByName(connection, name);
        }

        public void Update(IDbConnection connection, Storage storage, IDbTransaction transaction = null) =>
            this.storageRepository.Update(connection, storage);
    }
}