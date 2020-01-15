using CommercialApplication.DomainLayer.Repositories.CommandRequests;
using CommercialApplication.DomainLayer.Repositories.Commands.ActionCommands;
using CommercialApplication.DomainLayer.Repositories.Commands.Callers;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Action;
using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.ActionRepositories
{
    public class ActionRepository : IActionRepository
    {
        private readonly CommandActionCaller commandActionCaller;

        public ActionRepository()
        {
            this.commandActionCaller = new CommandActionCaller();
        }

        public void Delete(IDbConnection connection, Action actionEntity, IDbTransaction transaction = null)
        {
            /*connection.Execute(ActionQueries.Delete, new { id = actionEntity.Id });*/
            DeleteActionCommand command = (DeleteActionCommand)this.commandActionCaller.DictCommands[ActionCommandRequests.Delete];
            command.Execute(connection, actionEntity, transaction);
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.ExecuteScalar<bool>(ActionQueries.Exists, new { id });*/
            IsActionExistCommand command = (IsActionExistCommand)this.commandActionCaller.DictCommands[ActionCommandRequests.IsActionExist];
            return command.Execute(connection, id, transaction);
        }

        public IEnumerable<Action> Select(IDbConnection connection, IDbTransaction transaction = null)
        {
            /*return connection.QueryFirst<IEnumerable<Action>>(ActionQueries.Select);*/
            GetAllActionCommand command = (GetAllActionCommand)this.commandActionCaller.DictCommands[ActionCommandRequests.GetAll];
            return command.Execute(connection, transaction);
        }

        public Action SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.QueryFirst<Action>(ActionQueries.SelectById, new { id });*/
            GetActionCommand command = (GetActionCommand)this.commandActionCaller.DictCommands[ActionCommandRequests.Get];
            return command.Execute(connection, id, transaction);
        }

        public void Insert(IDbConnection connection, Action actionEntity, IDbTransaction transaction = null)
        {
            /*connection.Execute(ActionQueries.Insert, new
            {
                productId = actionEntity.ProductId.Content,
                discount = actionEntity.Discount.Content,
                customerId = actionEntity.CustomerId.Content,
                thresholdAmount = actionEntity.ThresholdAmount.Content
            });*/
            InsertActionCommand command = (InsertActionCommand)this.commandActionCaller.DictCommands[ActionCommandRequests.Insert];
            command.Execute(connection, actionEntity, transaction);
        }

        public IEnumerable<Action> SelectByCustomerId(IDbConnection connection, ActionDto actionDto, IDbTransaction transaction = null)
        {
            return connection.Query<Action>(ActionQueries.SelectByCustomerId, new
            {
                productId = actionDto.ProductId,
                customerId = actionDto.CustomerId
            });
        }

        public void Update(IDbConnection connection, Action actionEntity, IDbTransaction transaction = null)
        {
            /*connection.Execute(ActionQueries.Update, new
            {
                id = actionEntity.Id,
                productId = actionEntity.ProductId.Content,
                discount = actionEntity.Discount.Content
            });*/
            UpdateActionCommand command = (UpdateActionCommand)this.commandActionCaller.DictCommands[ActionCommandRequests.Update];
            command.Execute(connection, actionEntity, transaction);
        }

        public void UpdateByCustomerId(IDbConnection connection, Action actionEntity, IDbTransaction transaction = null)
        {
            /*connection.Execute(ActionQueries.UpdateByCustomerId, new
            {
                productId = actionEntity.ProductId.Content,
                customerId = actionEntity.CustomerId.Content,
                thresholdAmount = actionEntity.ThresholdAmount.Content,
                discount = actionEntity.Discount.Content
            });*/
            UpdateActionCommandByCustomerId command = (UpdateActionCommandByCustomerId)this.commandActionCaller.DictCommands[ActionCommandRequests.UpdateActionByCustomerId];
            command.Execute(connection, actionEntity, transaction);
        }

        public void UpdateBySalesChannelId(IDbConnection connection, Action actionEntity, IDbTransaction transaction = null)
        {
            connection.Execute(ActionQueries.UpdateBySalesChannelId, new
            {
                productId = actionEntity.ProductId.Content,
                salesChannelId = actionEntity.SalesChannelId.Content,
                thresholdAmount = actionEntity.ThresholdAmount.Content,
                discount = actionEntity.Discount.Content
            });
        }
    }
}