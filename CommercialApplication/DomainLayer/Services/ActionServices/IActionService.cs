using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.ActionServices
{
    public interface IActionService
    {
        IEnumerable<ActionEntity> Select(IDbConnection connection, IDbTransaction transaction = null);
        ActionEntity SelectById(IDbConnection connection, long id, IDbTransaction transaction = null);
        void Insert(IDbConnection connection, ActionEntity actionEntity, IDbTransaction transaction = null);

        void Update(IDbConnection connection, ActionEntity actionEntity, IDbTransaction transaction = null);

        void UpdateByCustomerId(IDbConnection connection, ActionEntity actionEntity, IDbTransaction transaction = null);
        void UpdateBySalesChannelId(IDbConnection connection, ActionEntity actionEntity, IDbTransaction transaction = null);

        void Delete(IDbConnection connection, ActionEntity actionEntity, IDbTransaction transaction = null);

        IEnumerable<ActionEntity> SelectByCustomerId(IDbConnection connection, ActionDto actionDto, IDbTransaction transaction = null);

    }
}