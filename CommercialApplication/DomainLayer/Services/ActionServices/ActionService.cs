using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.ActionRepositories;
using CommercialApplicationCommand.DomainLayer.Repositories.Factory;
using System.Collections.Generic;
using System.Data;

namespace CommercialApplicationCommand.DomainLayer.Services.ActionServices
{
    public class ActionService : IActionService
    {
        private readonly IActionRepository actionRepository;

        public ActionService()
        {
            this.actionRepository = RepositoryFactory.CreateActionRepository();
        }


        public IEnumerable<ActionEntity> Select(IDbConnection connection, IDbTransaction transaction = null)
        {
            return this.actionRepository.Select(connection);
        }

        public ActionEntity SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return this.actionRepository.SelectById(connection, id);
        }



        public void Delete(IDbConnection connection, ActionEntity actionEntity, IDbTransaction transaction = null)
        {
            this.actionRepository.Delete(connection, actionEntity);
        }

        public void Insert(IDbConnection connection, ActionEntity actionEntity, IDbTransaction transaction = null)
        {
            this.actionRepository.Insert(connection, actionEntity);
        }

        public IEnumerable<ActionEntity> SelectByCustomerId(IDbConnection connection, ActionDto actionDto, IDbTransaction transaction = null)
        {
            return this.actionRepository.SelectByCustomerId(connection, actionDto);
        }

        public void Update(IDbConnection connection, ActionEntity actionEntity, IDbTransaction transaction = null)
        {
            this.actionRepository.Update(connection, actionEntity);
        }

        public void UpdateByCustomerId(IDbConnection connection, ActionEntity actionEntity, IDbTransaction transaction = null)
        {
            this.actionRepository.UpdateByCustomerId(connection, actionEntity);
        }

        public void UpdateBySalesChannelId(IDbConnection connection, ActionEntity actionEntity, IDbTransaction transaction = null)
        {
            this.actionRepository.UpdateBySalesChannelId(connection, actionEntity);
        }
    }
}