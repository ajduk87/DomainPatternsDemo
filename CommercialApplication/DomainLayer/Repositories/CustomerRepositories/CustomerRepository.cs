using CommercialApplication.DomainLayer.Repositories.CommandRequests;
using CommercialApplication.DomainLayer.Repositories.Commands.Callers;
using CommercialApplication.DomainLayer.Repositories.Commands.CustomerCommands;
using CommercialApplication.DomainLayer.Repositories.Sql;
using CommercialApplicationCommand.ApplicationLayer.Dtoes.Customer;
using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using CommercialApplicationCommand.DomainLayer.Repositories.Sql;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommercialApplicationCommand.DomainLayer.Repositories.CustomerRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CommandCustomerCaller commandCustomerCaller;

        public CustomerRepository()
        {
            this.commandCustomerCaller = new CommandCustomerCaller();
        }


        public IEnumerable<Customer> Select(IDbConnection connection, IDbTransaction transaction = null)
        {
            /*return connection.Query<Customer>(CustomerQueries.Select);*/
            GetAllCustomerCommand command = (GetAllCustomerCommand)this.commandCustomerCaller.DictCommands[CustomerCommandRequests.GetAll];
            return command.Execute(connection, transaction);
        }

        public Customer SelectById(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.Query<Customer>(CustomerQueries.SelectById, new { id }).Single();*/
            GetCustomerCommand command = (GetCustomerCommand)this.commandCustomerCaller.DictCommands[CustomerCommandRequests.Get];
            return command.Execute(connection, id, transaction);
        }

        public void Insert(IDbConnection connection, Customer customer, IDbTransaction transaction = null)
        {
            /*connection.Execute(CustomerQueries.Insert, new { Name = customer.Name.Content });*/
            CreateNewCustomerInfoCommand command = (CreateNewCustomerInfoCommand)this.commandCustomerCaller.DictCommands[CustomerCommandRequests.CreateNewCustomerInfo];
            command.Execute(connection, customer, transaction);
        }

        public void Update(IDbConnection connection, Customer customer, IDbTransaction transaction = null)
        {
            /*connection.Execute(CustomerQueries.Update, new { id = customer.Id, Name = customer.Name.Content });*/
            UpdateExistingCustomerInfoCommand command = (UpdateExistingCustomerInfoCommand)this.commandCustomerCaller.DictCommands[CustomerCommandRequests.UpdateExistingCustomerInfo];
            command.Execute(connection, customer, transaction);
        }

        public void Delete(IDbConnection connection, Customer customer, IDbTransaction transaction = null)
        {
            /*connection.Execute(CustomerQueries.Delete, new { id = customer.Id });*/
            RemoveExistingCustomerInfoCommand command = (RemoveExistingCustomerInfoCommand)this.commandCustomerCaller.DictCommands[CustomerCommandRequests.RemoveExistingCustomerInfo];
            command.Execute(connection, customer, transaction);
        }

        public bool Exists(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            /*return connection.ExecuteScalar<bool>(CustomerQueries.Exists, new { id });*/
            IsCustomerExistCommand command = (IsCustomerExistCommand)this.commandCustomerCaller.DictCommands[CustomerCommandRequests.IsCustomerExist];
            return command.Execute(connection, id, transaction);
        }
    }
}