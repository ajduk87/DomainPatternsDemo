using CommercialApplicationCommand.ApplicationLayer.Dtoes.Storage;
using CommercialApplicationCommand.DomainLayer.Entities.StorageEntities;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.StorageServices
{
    internal interface IStorageService
    {
        StorageDto SelectByName(IDbConnection connection, Name name, IDbTransaction transaction = null);

        void Insert(IDbConnection connection, Storage storage, IDbTransaction transaction = null);

        void Update(IDbConnection connection, Storage storage, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, Storage storage, IDbTransaction transaction = null);
    }
}