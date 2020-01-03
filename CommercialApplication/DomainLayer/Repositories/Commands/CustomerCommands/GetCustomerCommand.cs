using CommercialApplicationCommand.DomainLayer.Entities.CustomerEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.CustomerCommands
{
    public class GetCustomerCommand : CommandBase, ICustomerCommand
    {
        public Customer Execute(IDbConnection connection, long id, IDbTransaction transaction = null)
        {
            return new Customer();
        }
    }
}
